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

public class GameManager : MonoBehaviour {

    static public void StartGame() {
        GameManager.gameController.InitGameConfigure();
        GameManager.spaceController.InitSpaceMap();
        //GameManager.spaceCreator.InitSpace();
    }


    /// <summary>
    /// 加载保存游戏配置
    /// </summary>
    static private GameController _gameController = null;
    static public GameController gameController {
        get {
            if ( _gameController == null ) {
                _gameController = new GameController();
            }
            return _gameController;
        }
    }


    /// <summary>
    /// 空间地图的初始化,变化,跳跃
    /// </summary>
    static private SpaceController _spaceController = null;
    static public SpaceController spaceController {
        get {
            if ( _spaceController == null ) {
                _spaceController = new SpaceController();
            }
            return _spaceController;
        }
    }


    /// <summary>
    /// 具体的空间操作,生成,清除
    /// </summary>
    static private SpaceCreator _spaceCreator = null;
    static public SpaceCreator spaceCreator {
        get{
            if( _spaceCreator == null ){
                _spaceCreator = new SpaceCreator(); 
            }
            return _spaceCreator;
        }
    }


   
}