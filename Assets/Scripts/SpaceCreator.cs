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

public class SpaceCreator : MonoBehaviour {

    SpaceWorld space;

    /// <summary>
    /// 获取将要进入的空间ID和空间元素数据,然后初始化空间
    /// </summary>
    public void InitSpace() {
        int nextSpaceId = GameManager.gameController.GetNextSpaceId();
        space = GameManager.spaceController.GetSpaceWorldById( nextSpaceId );

        foreach ( SpaceItem item in space.items ) {
            GameObject obj = GameObjectPool.GetGameObjectByName( item.item_name );
            if ( obj != null ) {
                obj.transform.position = item.item_pos;
                obj.transform.rotation = item.item_rot;
                obj.transform.localScale = item.item_scale;
                obj.name = item.item_name;
            } else {
                Debug.LogError( item.item_name + " Load Faild!!!" );
            }
        }
        
    }


    /// <summary>
    /// 清除整个空间数据
    /// </summary>
    public void ClearSpace() {
        string levelName = Application.loadedLevelName;
        Application.LoadLevel( levelName );        
    }


    public void SpaceJumpOver() {
        ClearSpace();
        InitSpace();
    }
}
