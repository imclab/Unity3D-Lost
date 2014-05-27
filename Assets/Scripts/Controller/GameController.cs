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
using System.IO;
using Com.Lost.GameData;
using System.Collections.Generic;
using System.Xml;
using JsonFx.Json;
using ID_MAP = System.String;

public class GameController {


    public void StartGame()
    {
        GameManager.gameDataController.InitGameData();
        IsGameStarted = true;
    }



    public bool IsGameStarted {
        get;
        set;
    }



    /// <summary>
    /// First game time, this is default configure, generate space id matrix, and choose the first space of world
    /// </summary>
    public void InitGameDefault()
    {
        int idCharsLength = ConstantParams.idChars.Length;
        SpaceFileItem mapFileId;
        List<string> tmp_ids = new List<string>();
        string tmp_id;
        for ( int i = 0; i < ConstantParams.spaceMatrixSize; ++i )
        {
            do
            {
                tmp_id = string.Format( "{0}{1}{2}{3}{4}", ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )] );
            } while ( tmp_ids.Contains( tmp_id ) );
            mapFileId = new SpaceFileItem();
            mapFileId.id = tmp_id;
            mapFileId.fileName = ConstantParams.file_space + ( i + 1 ).ToString();
            GameManager.gameDataController.gameConfigure.SpaceMapMatrix[i] = mapFileId;
        }
        GameManager.gameDataController.gameConfigure.IsFirstGameTime = false;
        GameManager.gameDataController.gameConfigure.nextSpace =
            (SpaceFileItem)GameManager.gameDataController.gameConfigure.SpaceMapMatrix[(int)Random.Range( 0, ConstantParams.spaceMatrixSize )];
    }


  
    public SpaceFileItem[] GetSpaceMatrix() {
        return GameManager.gameDataController.gameConfigure.SpaceMapMatrix;
    }


    public SpaceFileItem GetNextSpace() {
        return GameManager.gameDataController.gameConfigure.nextSpace;
    }


    public SpaceFileItem GetCurrentSpace() 
    {
        return GameManager.gameDataController.gameConfigure.nextSpace;
    }


    public SpaceWorld GetNextSpaceWorld()
    {
        SpaceFileItem nextSpace = GetNextSpace();
        SpaceWorld nextSpaceWorld = new SpaceWorld();
        if ( GameManager.gameDataController.spaces.TryGetValue( nextSpace, out nextSpaceWorld ) )
        {
            return nextSpaceWorld;
        }
        else
        {
            return null;
        }
    }


    public void SetNextSpace( SpaceFileItem id ) {
        GameManager.gameDataController.gameConfigure.nextSpace = id;
    }

}
