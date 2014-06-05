using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class SpecialAttributeManager {
    static private SpecialAttributeManager _specialAttributeManager = null;
    static public SpecialAttributeManager Instance
    {
        get
        {
            if (_specialAttributeManager == null)
            {
                _specialAttributeManager = new SpecialAttributeManager();
            }
            return _specialAttributeManager;
        }
    }


    static private JumpTubeAttrController _jumpAttrController = null;
    static public JumpTubeAttrController jumpAttrController
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

    public void GetById(int id)
    {

    }

}



