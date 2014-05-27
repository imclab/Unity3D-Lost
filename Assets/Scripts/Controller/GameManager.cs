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
    static public SpaceCreator spaceCreator
    {
        get
        {
            if ( _spaceCreator == null )
            {
                _spaceCreator = new SpaceCreator();
            }
            return _spaceCreator;
        }
    } 



    /// <summary>
    /// 保存不同物体的脚本属性，通过Json
    /// </summary>
    static private AttributeSystem _attributeSystem = null;
    static public AttributeSystem attributeSystem {
        get {
            if( _attributeSystem == null ) {
                _attributeSystem = new AttributeSystem();
            }
            return _attributeSystem;
        }
    }



    static private GameDataController _gameDataController = null;
    static public GameDataController gameDataController
    {
        get
        {
            if ( _gameDataController == null )
            {
                _gameDataController = new GameDataController();
            }
            return _gameDataController;
        }
    }
    
   
}