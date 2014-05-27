/*
================================================================================
FileName    : 
Description : 所有游戏数据的集中加载与保存
Date        : 2014-05-27
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using Com.Lost.GameData;
using JsonFx.Json;
using System.Collections.Generic;

public class GameDataController {
    public GameConfigure gameConfigure = new GameConfigure();
    public ArrayList elementsAttributes = new ArrayList();
    public Dictionary<SpaceFileItem,SpaceWorld> spaces = new Dictionary<SpaceFileItem, SpaceWorld>();


    public bool IsLoadFinished
    {
        get;
        set;
    }


    /// <summary>
    /// Load all game data from file
    /// </summary>
    public void InitGameData()
    {
        if ( LoadGameConfigure() == -1 )
        {
            GameManager.gameController.InitGameDefault();
            SaveGameConfigure();
        }

        LoadSpaces();
        LoadAttributes();
    }


    /// <summary>
    /// Load game configure data
    /// </summary>
    /// <returns>0: Successful    1: Faild</returns>
    public int LoadGameConfigure()
    {
        string gameConfigureDataStr = DataCenter.LoadDataFromFile( Application.streamingAssetsPath + "/", ConstantParams.file_gameConfigure, false );
        if ( gameConfigureDataStr == null )        // File not exists
        {
            return -1;
        }
        gameConfigure = JsonReader.Deserialize<GameConfigure>( gameConfigureDataStr );
        return 0;
    }
    /// <summary>
    /// Save game configure data
    /// </summary>
    public void SaveGameConfigure()
    {
        string gameConfigureDataStr = JsonWriter.Serialize( gameConfigure );
        DataCenter.SaveDataToFile( gameConfigureDataStr, Application.streamingAssetsPath + "/", ConstantParams.file_gameConfigure, false );
    }




    /// <summary>
    /// After game configure loaded, you can load all space world from file, according array of SpaceFileItem in gameConfigure.
    /// </summary>
    /// <returns></returns>
    public int LoadSpaces()
    {
        foreach ( SpaceFileItem sfi in gameConfigure.SpaceMapMatrix )
        {
            string spaceDataStr = DataCenter.LoadDataFromFile( Application.streamingAssetsPath + "/SpaceWorlds/", sfi.fileName, false);
            if ( spaceDataStr != null )
            {
                SpaceWorld spaceWorld = JsonReader.Deserialize<SpaceWorld>( spaceDataStr );
                spaces.Add( sfi, spaceWorld );
                Debug.Log( "Add Space: " + sfi.fileName + "    " + spaceWorld.items.Length);
            }
        }
        return 0;
    }




    public int LoadAttributes()
    {
        elementsAttributes.Clear();
        string attributeJsonStr = DataCenter.LoadDataFromFile( Application.streamingAssetsPath + "/", ConstantParams.file_attribute, false );
        Debug.Log( "AttributeJsonStr: " + attributeJsonStr );
        if ( attributeJsonStr == null )
        {
            elementsAttributes = new ArrayList();
            Debug.Log( "No attributeJsonStr...." );
            return -1;
        }
        ElementAtrribute[] attributes = JsonFx.Json.JsonReader.Deserialize<ElementAtrribute[]>( attributeJsonStr );

        foreach( ElementAtrribute attr in attributes ) {
            elementsAttributes.Add( attr );
        }

        Debug.Log( "Count: " + attributes.Length );
        GameManager.attributeSystem.InitIds();
        return 0;
    }



    public void SaveAttributes()
    {
        string attributeJsonStr = JsonWriter.Serialize( elementsAttributes );
        Debug.Log( "Save Attributes: " +  attributeJsonStr );
        DataCenter.SaveDataToFile( attributeJsonStr, Application.streamingAssetsPath + "/", ConstantParams.file_attribute, false );

    }
}


[System.Serializable]
public class ElementAtrribute {
    public ElementAtrribute() { }
    public int id;
    public string attributeJsonStr;
}
