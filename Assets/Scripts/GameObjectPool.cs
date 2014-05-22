using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPool {
    static private List<Item> objects = new List<Item>();
    void Start() {
        
    }


    static public GameObject GetGameObjectByName( string name ) {

        foreach ( Item item in objects ) {
            if ( item.name == name ) {
                GameObject obj = MonoBehaviour.Instantiate( item.obj ) as GameObject;
                return obj;
            }
        }

        Item gItem = new Item();
        gItem.name = name;
        gItem.obj = Resources.Load( "Prefab/" + name ) as GameObject;

        if ( gItem.obj == null ) {
            return null;
        }

        objects.Add( gItem );

        return MonoBehaviour.Instantiate( gItem.obj ) as GameObject;
    }
    

}



class Item {
    public string name;
    public GameObject obj;
}