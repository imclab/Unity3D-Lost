
using UnityEngine;
using System.Collections;

public class GameWorldCreator {
	public delegate void CreateGameWorldOverCallback();

    public void CreateGameWorld( MonoBehaviour mono, int id, CreateGameWorldOverCallback callback )
    {
        mono.StartCoroutine( CreateGameWorld( id, callback ) );
    }

	public IEnumerator CreateGameWorld(int id, CreateGameWorldOverCallback callback)
    {
        MGameWorld gameworld = GlobalManager.Instance.gameWorldController.GetGameWorldById( id );
        foreach( MItem item in gameworld.items )
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(item.NAME)) as GameObject;
            obj.GetComponent<BaseItem>().baseData = item;
            obj.SendMessage( "InitBaseAttribute", SendMessageOptions.DontRequireReceiver );
        }

        if( callback != null )
        {
            callback();
        }
        yield return 0;

	}

}
