using UnityEngine;
using System.Collections;
using System.IO;

public class AttributeSystem  {
    private int id = 1;

    public void AddElementAttribute(ElementAtrribute attribute){
        GameManager.gameDataController.elementsAttributes.Add( attribute );
    }


    public ElementAtrribute GetAttributeStrByID( int id ) {
        foreach ( ElementAtrribute attribute in GameManager.gameDataController.elementsAttributes )
        {
            if( attribute.id == id ) {
                return attribute;
            }
        }

        return null;
    }


    public int GetUniqueID() {
        return id++;
    }

}


[System.Serializable]
public class ElementAtrribute {
    public int id;
    public string attributeJsonStr;
}