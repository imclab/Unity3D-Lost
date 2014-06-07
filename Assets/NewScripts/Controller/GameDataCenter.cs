/*
================================================================================
FileName    : 
Description : 根据不同平台获取相关数据文件的路径，将数据写入磁盘
Date        : 2014-06-07
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using System.IO;

public class GameDataCenter  {

    static public string GetSpecialAttributeFilePath(string fileName)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return Application.streamingAssetsPath + "/SpecialAttribute/" + fileName;
        }
        else if( Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            return Application.dataPath + "/StreamingAssets/SpecialAttribute/" + fileName;
        }
        else
        {
            return Application.streamingAssetsPath + "/SpecialAttribute/" + fileName;
        }
    }


    static public string GetGameWorldFilePath( int id )
    {
        return Application.streamingAssetsPath + "/GameWorlds/" + DataFileName.GameWorld + id.ToString();
    }

    static public string GetGameConfigureFilePath()
    {
        return Application.streamingAssetsPath + "/" + DataFileName.GameConfigure;
    }

    static public void WriteDataToFile(string data, string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        StreamWriter writer = File.CreateText(filePath);
        writer.Write(data);
        writer.Close();        
    }

	
}
