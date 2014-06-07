/*
================================================================================
FileName    : 
Description : 载入所有的游戏世界数据，存储在list中，根据ID返回相应的游戏世界数据
Date        : 2014-06-07
Author      : ss0x53
Version     : 
================================================================================
*/
using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

public class GameWorldDataManager
{
    List<MGameWorld> gameWorlds = new List<MGameWorld>();


    /*
    public void LoadGameWorlds(MonoBehaviour mono, LoadDataOverCallback callback = null){
        mono.StartCoroutine( LoadGameWorlds( callback ) );
    }
     */



    public IEnumerator LoadGameWorlds( )
    {
        gameWorlds.Clear();
        for( int i = 1; i <= 25; ++i )
        {
            FileStream fs = new FileStream( GameDataCenter.GetGameWorldFilePath( i ) ,FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(MGameWorld));
            MGameWorld world = (MGameWorld)serializer.Deserialize( fs );
            gameWorlds.Add( world );            
        }
        
        yield return 0;
    }


    public MGameWorld GetGameWorldById( int id )
    {
        foreach( MGameWorld gw in gameWorlds )
        {
            if( gw.id == id )
            {
                return gw;
            }
        }

        return null;
    }

}