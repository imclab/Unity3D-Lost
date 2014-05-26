using UnityEngine;
using System.Collections;
using System.IO;

public class AttributeSystem  {
    ArrayList attributes = new ArrayList();
    private int id = 1;

    public ArrayList GetAllElementsAttribute() {
        return attributes;
    }
    

    public void AddElementAttribute(ElementAtrribute attribute){
        attributes.Add( attribute );
    }


    public ElementAtrribute GetAttributeByID( int id ) {
        foreach( ElementAtrribute attribute in attributes ) {
            if( attribute.id == id ) {
                return attribute;
            }
        }

        return null;
    }


    public int GetUniqueID() {
        return id++;
    }


    public void SaveAllAttribute() {
        string attributeJsonStr = JsonFx.Json.JsonWriter.Serialize( attributes );
        DataCenter.SaveDataToFile( attributeJsonStr, Application.streamingAssetsPath + "/", ConstantParams.file_attribute, false );
    }


    public void LoadAllAttribute() {
        if( !File.Exists(Application.streamingAssetsPath + "/" + ConstantParams.file_attribute )){
            return;
        }
        string attributeJsonStr = DataCenter.LoadDataFromFile( Application.streamingAssetsPath + "/", ConstantParams.file_attribute, false );
        attributes = JsonFx.Json.JsonReader.Deserialize( attributeJsonStr ) as ArrayList;
    }


}


[System.Serializable]
public class ElementAtrribute {
    public int id;
    public string attributeJsonStr;
}