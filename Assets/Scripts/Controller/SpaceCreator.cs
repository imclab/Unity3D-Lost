/*
================================================================================
FileName    : 
Description : 
Date        : 2014-05-23
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using Com.Lost.GameData;
using JsonFx.Json;
public class SpaceCreator : MonoBehaviour {

  

    SpaceWorld spaceWorld;

    void Start()
    {
        InitSpace();
    }

    /// <summary>
    /// 获取将要进入的空间ID和空间元素数据,然后初始化空间
    /// </summary>
    public void InitSpace() {
        spaceWorld = GameManager.gameController.GetNextSpaceWorld();
        if ( spaceWorld != null )        // get space world successful
        {
            foreach ( SpaceItem item in spaceWorld.items )
            {
                GameObject obj = MonoBehaviour.Instantiate( Resources.Load( item.item_name ) ) as GameObject;
                obj.SendMessage( "LoadMyAttribute", item.uid, SendMessageOptions.DontRequireReceiver );
                obj.name = item.item_name;
                obj.transform.position = new Vector3( item.item_pos.x, item.item_pos.y, item.item_pos.z );
                obj.transform.rotation = new Quaternion( item.itme_rot.x, item.itme_rot.y, item.itme_rot.z, item.itme_rot.w );
                obj.transform.localScale = new Vector3( item.item_scale.x, item.item_scale.y, item.item_scale.z );
                obj.SetActive( item.isActive );
            }
        }
    }



}
