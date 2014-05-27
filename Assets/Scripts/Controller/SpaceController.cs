/*
================================================================================
FileName    : 
Description : 
Date        : 2014-05-23
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Com.Lost.GameData;



public class SpaceController {

    /// Width and height of 2D space world id matrix
    int size = (int)Mathf.Sqrt(ConstantParams.spaceMatrixSize);

    /// 2D space map, every element has 2 item, the space id , and definite space world file's  name;
    SpaceFileItem[,] spaceMap;

    private int _spaceMapBorder = (int)Mathf.Sqrt( ConstantParams.spaceMatrixSize ) - 1;


    /// <summary>
    /// 从一维数组中提取绑定在一起的ID和文件名对象,做为二维空间地图的一个元素
    /// </summary>
    public void InitSpaceMap()
    {
        spaceMap = new SpaceFileItem[size, size];
        SpaceFileItem[] spaces = GameManager.gameController.GetSpaceMatrix();
        int readIndex = 0;
        for ( int row = 0; row < size; ++row )
        {
            for ( int col = 0; col < size; ++col )
            {
                spaceMap[row, col] = spaces[readIndex++];
            }
        }

    }


    /// <summary>
    /// 玩家选择一次跳跃后,当前所在位置的行或列,所有元素向正方向平移2个单位,变换空间矩阵
    /// </summary>
    /// <param name="currentPos"></param>
    /// <param name="dir"></param>
    public void TransformSpaceMap( Vector2 currentCoordinate, SpaceJumpDirection_t dir )
    {

        int spaceRow = (int)currentCoordinate.y;
        int spaceCol = (int)currentCoordinate.x;

        int cPoint = 0;
        int nPoint;
        SpaceFileItem cValue;
        SpaceFileItem nValue;

        switch ( dir )
        {
            // 列平移
            case SpaceJumpDirection_t.Left:
            case SpaceJumpDirection_t.Right:
                cValue = spaceMap[cPoint, spaceCol];
                for ( int count = 0; count <= _spaceMapBorder; ++count )
                {
                    nPoint = cPoint + 2;
                    if ( nPoint > _spaceMapBorder )
                    {
                        nPoint = nPoint % _spaceMapBorder - 1;
                    }

                    nValue = spaceMap[nPoint, spaceCol];
                    spaceMap[nPoint, spaceCol] = cValue;
                    cValue = nValue;
                    cPoint = nPoint;
                }
                break;
            // 行平移
            case SpaceJumpDirection_t.Up:
            case SpaceJumpDirection_t.Down:
                cValue = spaceMap[spaceRow, cPoint];
                for ( int count = 0; count <= _spaceMapBorder; ++count )
                {
                    nPoint = cPoint + 2;
                    if ( nPoint > _spaceMapBorder )
                    {
                        nPoint = nPoint % _spaceMapBorder - 1;
                    }

                    nValue = spaceMap[spaceRow, nPoint];
                    spaceMap[spaceRow, nPoint] = cValue;
                    cValue = nValue;
                    cPoint = nPoint;
                }
                break;
        }
    }


    /// <summary>
    /// 玩家选择跳跃隧道后, 根据当前空间ID和跳跃方向,选择下一个空间世界,
    /// </summary>
    /// <param name="currentPos"></param>
    /// <param name="dir"></param>
    public void SpaceJump( SpaceJumpDirection_t dir )
    {
        SpaceFileItem currentSpaceId = GameManager.gameController.GetCurrentSpace();
        Vector2 currentSpacePos = GetCoordinateBySpaceId( currentSpaceId );
        Vector2 nextSpacePos = Vector2.zero;
        int nextSpaceRow,nextSpaceCol;

        switch ( dir )
        {
            case SpaceJumpDirection_t.Left:
                nextSpacePos = currentSpacePos + new Vector2( -1, 0 );
                if ( nextSpacePos.x < 0 )
                {
                    nextSpacePos.x = _spaceMapBorder;
                }
                break;

            case SpaceJumpDirection_t.Right:
                nextSpacePos = currentSpacePos + new Vector2( 1, 0 );
                if ( nextSpacePos.x > _spaceMapBorder )
                {
                    nextSpacePos.x = 0;
                }
                break;

            case SpaceJumpDirection_t.Up:
                nextSpacePos = currentSpacePos + new Vector2( 0, -1 );
                if ( nextSpacePos.y < 0 )
                {
                    nextSpacePos.y = _spaceMapBorder;
                }
                break;

            case SpaceJumpDirection_t.Down:
                nextSpacePos = currentSpacePos + new Vector2( 0, 1 );
                if ( nextSpacePos.y > _spaceMapBorder )
                {
                    nextSpacePos.y = 0;
                }
                break;
        }

        nextSpaceRow = (int)nextSpacePos.y;
        nextSpaceCol = (int)nextSpacePos.x;
        GameManager.gameController.SetNextSpace( spaceMap[nextSpaceRow, nextSpaceCol] );

        TransformSpaceMap( currentSpacePos, dir );
        GameManager.spaceCreator.SpaceJumpOver();
    }


    /// <summary>
    /// 根据ID查找当前空间座标, 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private Vector2 GetCoordinateBySpaceId( SpaceFileItem id )
    {
        int spaceSize = (int)Mathf.Sqrt( ConstantParams.spaceMatrixSize );
        Vector2 coordinate = Vector2.zero;
        for ( int y = 0; y < spaceSize; ++y )
        {
            for ( int x = 0; x < spaceSize; ++x )
            {
                if ( spaceMap[y, x] == id )
                {
                    coordinate = new Vector2( x, y );
                    return coordinate;
                }
            }
        }
        return coordinate;
    }
}
