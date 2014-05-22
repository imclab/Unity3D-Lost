using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SpaceController {

    int size = (int)Mathf.Sqrt(ConstantParams.spaceMatrixSize);
    int [,] spaceMap;

    List<SpaceWorld> Spaces = new List<SpaceWorld>();


    /// <summary>
    /// 从一维二进制数组中解析出所有空间ID,初始化到二维矩阵,作为空间地图
    /// </summary>
    public void InitSpaceMap() {
        spaceMap = new int[size, size];
        byte[] spaceMatrix = GameManager.gameController.GetSpaceMatrix();
        int readIndex = 0;

        for ( int row = 0; row < size; ++row ) {
            for ( int col = 0; col < size; ++col ) {
                int id = BitConverter.ToInt16( spaceMatrix, readIndex );
                readIndex += 2;
                spaceMap[row, col] = id;
            }
        }

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentPos"></param>
    /// <param name="dir"></param>
    public void TransformSpaceMap( Vector2 currentCoordinate, SpaceJumpDirection_t dir ) {
        switch ( dir ) {
            case SpaceJumpDirection_t.Left:

                break;
            case SpaceJumpDirection_t.Right:

                break;

            case SpaceJumpDirection_t.Up:

                break;
            case SpaceJumpDirection_t.Down:

                break;
        }
    }


    /// <summary>
    /// 玩家选择跳跃隧道后,将触发此函数
    /// </summary>
    /// <param name="currentPos"></param>
    /// <param name="dir"></param>
    public void SpaceJump( int currentSpaceId, SpaceJumpDirection_t dir ) {
        // --------------- Search coordinate of this id -----------------------
        switch ( dir ) {
            case SpaceJumpDirection_t.Left:
                //GameManager.gameController.SetNextSpaceId(?);
                break;
            case SpaceJumpDirection_t.Right:

                break;

            case SpaceJumpDirection_t.Up:

                break;
            case SpaceJumpDirection_t.Down:

                break;
        }

       // TransformSpaceMap( currentSpacePos, dir );
        GameManager.spaceCreator.SpaceJumpOver();
    }



    /*
     <root>
       <SpaceWorld id=123>
     *   <item>
     *     <name>Ground</name>
     *     <pos>x_y_z</pos>
     *     <rot>x_y_z</rot>
     *     <scale>x_y_z</scale>
     *   </item>
     *   <item>
     *     ....
     *     ....
     *     ....
     *     ....
     *   </item>
     * </SpaceWorld>
     *   
     *
     */
    /// <summary>
    /// 载入所有空间数据,并解析到Spaces中
    /// </summary>
    void LoadAllSpaceWorld() {

    }


    /// <summary>
    /// 根据空间ID,返回对应空间的数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SpaceWorld GetSpaceWorldById( int id ) {
        foreach ( SpaceWorld sw in Spaces ) {
            if ( sw.spaceId == id ) {
                return sw;
            }
        }
        return null;
    }
}




public enum SpaceJumpDirection_t {
    Left,
    Right,
    Up,
    Down,
}