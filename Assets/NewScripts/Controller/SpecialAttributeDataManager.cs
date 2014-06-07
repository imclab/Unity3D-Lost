/*
================================================================================
FileName    : 
Description : 游戏世界中各元素特有脚本属性的保存，载入，及序列化反序列化，获取等功能
Date        : 2014-06-07
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class SpecialAttributeDataManager
{


    public IEnumerator LoadAllSpecialAttribute(MonoBehaviour mono)
    {
        yield return mono.StartCoroutine( jumpAttrController.Load() );

    }



     private JumpTubeAttrController _jumpAttrController = null;
     public JumpTubeAttrController jumpAttrController
    {
        get
        {
            if (_jumpAttrController == null)
            {
                _jumpAttrController = new JumpTubeAttrController();
            }
            return _jumpAttrController;
        }
    }




}


public class JumpTubeAttrController
{

    List<MJumpTube> jumptubes = new List<MJumpTube>();

    public IEnumerator Load()
    {
        WWW www = new WWW(GameDataCenter.GetSpecialAttributeFilePath(DataFileName.JumpTubes));
        yield return www;
        if (www.error != null)
        {
            Debug.LogError("Load " + DataFileName.JumpTubes + " error!!");
        }
        else
        {
            TextReader fs = new StringReader(www.text);
            XmlSerializer serializer = new XmlSerializer(typeof(List<MJumpTube>));
            jumptubes = (List<MJumpTube>)serializer.Deserialize(fs);
            fs.Close();
        }

    }

    public void Save()
    {
        string data = "";
        XmlSerializer serializer = new XmlSerializer(typeof(List<MJumpTube>));
        StringWriter textWriter = new StringWriter();
        serializer.Serialize(textWriter, jumptubes);
        data = textWriter.ToString();
        GameDataCenter.WriteDataToFile(data, GameDataCenter.GetSpecialAttributeFilePath(DataFileName.JumpTubes));
    }

    public MJumpTube GetById(int id)
    {

        return null;
    }

    public void AddSpecialAttr(MJumpTube attr)
    {
        jumptubes.Add( attr );
    }

}



