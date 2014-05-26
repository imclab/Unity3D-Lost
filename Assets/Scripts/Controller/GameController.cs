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

    GameConfigure gameConfigure = new GameConfigure();
    public bool IsGameStarted {
        get;
        set;
    }
    public void InitGameConfigure() {
        IsGameStarted = true;
        LoadGameConfigure();
    }


    
    /// <summary>
    /// 载入游戏配置文件,解析初始化
    /// </summary>
    public void LoadGameConfigure() {
        if ( File.Exists( Application.streamingAssetsPath + "/" + ConstantParams.file_gameConfigure ) ) {
            string gameConfigureDataStr = DataCenter.LoadDataFromFile( Application.streamingAssetsPath + "/", ConstantParams.file_gameConfigure, false );
            gameConfigure = JsonReader.Deserialize<GameConfigure>( gameConfigureDataStr );
        } else {
            InitGameDefault();
            SaveGameConfigure();
        }


    }


    /// <summary>
    /// 将空间ID矩阵及当前ID保存到磁盘
    /// </summary>
    public void SaveGameConfigure() {
        string gameConfigureDataStr = JsonWriter.Serialize(gameConfigure);
        DataCenter.SaveDataToFile( gameConfigureDataStr, Application.streamingAssetsPath + "/", ConstantParams.file_gameConfigure, false );
    }


    /// <summary>
    /// 若第一次进入游戏,则生成默认配置文件,初始化空间矩阵,随机选择第一次进入的世界
    /// </summary>
    public void InitGameDefault() {
        int idCharsLength = ConstantParams.idChars.Length;
        SpaceFileItem mapFileId;
        List<string> tmp_ids = new List<string>();
        string tmp_id;
        for ( int i = 0; i < ConstantParams.spaceMatrixSize; ++i ) {

            do {
                tmp_id = string.Format( "{0}{1}{2}{3}{4}",  ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )],
                                                            ConstantParams.idChars[(int)Random.Range( 0, idCharsLength )] );
            } while ( tmp_ids.Contains( tmp_id ) );

            mapFileId = new SpaceFileItem();
            mapFileId.id = tmp_id;
            mapFileId.fileName = ConstantParams.file_space + ( i + 1 ).ToString();
            gameConfigure.SpaceMapMatrix[i] = mapFileId;
        }

        gameConfigure.IsFirstGameTime = false;
        gameConfigure.nextSpace = (SpaceFileItem)gameConfigure.SpaceMapMatrix[(int)Random.Range( 0, ConstantParams.spaceMatrixSize )];  
    }


    /// <summary>
    /// 返回存放着ID的一维二进制数组
    /// </summary>
    /// <returns></returns>
    public SpaceFileItem[] GetSpaceMatrix() {
        return gameConfigure.SpaceMapMatrix;
    }


    /// <summary>
    /// 返回游戏开始应该进入的空间ID
    /// </summary>
    /// <returns></returns>
    public SpaceFileItem GetNextSpace() {
        return gameConfigure.nextSpace;
    }


    public void SetNextSpace( SpaceFileItem id ) {
        gameConfigure.nextSpace = id;
    }

}
