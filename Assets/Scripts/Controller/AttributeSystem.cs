using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class AttributeSystem  {
    List<int> ids = new List<int>();
    
    public void AddElementAttribute(ElementAtrribute attribute){
        GameManager.gameDataController.elementsAttributes.Add( attribute );
        Debug.Log( "Add Attribute: " + attribute.id);
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


    public void RemoveAttributeByID( int id )
    {
        foreach ( ElementAtrribute attribute in GameManager.gameDataController.elementsAttributes )
        {
            if ( attribute.id == id )
            {
                GameManager.gameDataController.elementsAttributes.Remove( attribute );
                ids.Remove( id );
                break;
            }
        }
    }


    public void InitIds( )
    {
        ids.Clear();
        foreach ( ElementAtrribute attribute in GameManager.gameDataController.elementsAttributes )
        {
            ids.Add( attribute.id );
        }
    }


    public int GetUniqueID() {
        int idIndex = 0;
        do
        {
            ++idIndex;
        } while ( ids.Contains( idIndex ) );
        ids.Add( idIndex );
        return idIndex;
    }

}


