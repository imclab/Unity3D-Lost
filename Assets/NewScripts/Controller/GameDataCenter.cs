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
