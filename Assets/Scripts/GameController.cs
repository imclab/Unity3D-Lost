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

public class GameController {

    GameConfigure gameConfigure = new GameConfigure();

    public void InitGameConfigure() {
        LoadGameConfigure();
    }


    
    /// <summary>
    /// 载入游戏配置文件,解析初始化
    /// </summary>
    public void LoadGameConfigure() {
        byte[] gameData = DataCenter.LoadDataFromBinaryFile( Application.streamingAssetsPath + "/" + ConstantParams.file_gameConfigure );
        if ( gameData != null ) {
#if LR_DEBUG
            Debug.Log("You are first time in this game.!");
#endif
            gameConfigure = (GameConfigure)GameManager.protobufUtility.Deserialize( gameData, "GameConfigure" );
        } else {
            InitGameDefault();
            SaveGameConfigure();
        }


    }


    /// <summary>
    /// 将空间ID矩阵及当前ID保存到磁盘
    /// </summary>
    public void SaveGameConfigure() {
        byte[] configureData = GameManager.protobufUtility.Serialize( gameConfigure );
        DataCenter.SaveDataToBinaryFile( Application.streamingAssetsPath + "/" + ConstantParams.file_gameConfigure , configureData);
    }


    /// <summary>
    /// 若第一次进入游戏,则生成默认配置文件,初始化空间矩阵,随机选择第一次进入的世界
    /// </summary>
    private void InitGameDefault() {
        byte[] spaceMapMatrix = new byte[200];

        int writeIndex = 0;

        for ( short i = 1; i <= 100; ++i ) {
            byte[] id = System.BitConverter.GetBytes( i );
            System.Array.Copy(id,0,spaceMapMatrix,writeIndex,2);
            writeIndex += 2;
        }

        int initId = (int)Random.Range( 1, 101 );

        gameConfigure.isFirstGameTime = false;
        gameConfigure.spaceMapMatrix = spaceMapMatrix;
        gameConfigure.nextSpaceId = initId;
    }


    /// <summary>
    /// 返回存放着ID的一维二进制数组
    /// </summary>
    /// <returns></returns>
    public byte[] GetSpaceMatrix() {
        return gameConfigure.spaceMapMatrix;
    }


    /// <summary>
    /// 返回游戏开始应该进入的空间ID
    /// </summary>
    /// <returns></returns>
    public int GetNextSpaceId() {
        return gameConfigure.nextSpaceId;
    }


    public void SetNextSpaceId(int id) {
        gameConfigure.nextSpaceId = id;
    }
    
}
