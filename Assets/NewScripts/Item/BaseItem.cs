/*
================================================================================
FileName    : 
Description : 每一个被保存的物体都要添加此脚本，GameWorldCreator解析XML数据后，只读取
 *            Base Attribute中的name,以此去加载游戏对象，然后会给游戏对象发InitBaseAttribute
 *            消息，对象将自己管理，自己去初始化。
Date        : 2014-06-05
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour {
    public MItem baseData;


    /// <summary>
    /// GameWorldCreator创造世界后，将发送此消息。游戏对象初始数据设置完后，将发送InitSpecialAttribute，去初始化特有属性
    /// </summary>
    void InitBaseAttribute()
    {
        transform.position = baseData.POS;
        transform.eulerAngles = baseData.ROT;
        transform.localScale = baseData.SCALE;
        SendMessage( "InitSpecialAttribute", SendMessageOptions.DontRequireReceiver );        
    }
}
