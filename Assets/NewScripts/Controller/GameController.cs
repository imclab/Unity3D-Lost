using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

public class GameController {
    public GameConfigure gameConfigure;

    public IEnumerator LoadGameConfigure() 
    {
        FileStream fs = new FileStream( GameDataCenter.GetGameConfigureFilePath(), FileMode.Open );
        XmlSerializer serializer = new XmlSerializer( typeof( GameConfigure ) );
        gameConfigure = (GameConfigure)serializer.Deserialize( fs );

        yield return 0;       
    }

}
