using UnityEngine;
using System.Collections;
using System.IO;

public class GameController {

    GameConfigure gameConfigure = new GameConfigure();

    public void InitGame() {
        LoadGameConfigure();
    }

    
    /// <summary>
    /// 载入游戏配置文件,解析初始化
    /// </summary>
    public void LoadGameConfigure() {
        byte[] gameData = DataCenter.LoadDataFromBinaryFile( Application.streamingAssetsPath + "/" + ConstantParams.file_gameConfigure );
        if ( gameData != null ) {
            // Parse data to GameConfigure class
        } else {
            InitGameDefault();
            SaveGameConfigure();
        }


    }


    public void SaveGameConfigure() {
        
    }


    private void InitGameDefault() {

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
