/*
================================================================================
FileName    : 
Description : 特殊属性控制器，不同的物体拥有不同的控制器，同样的功能，根据基础属性ID，去获取相应的自身类型特殊属性。
              以及在编辑器状态下，将自身特殊属性添加到特殊属性总管理器，用于序列化到文件
Date        : 2014-06-07
Author      : ss0x53
Version     : 
================================================================================
*/
using UnityEngine;
using System.Collections;

public class JumpTube : MonoBehaviour
{
    public MJumpTube jumpTubeData;

    void InitSpecialAttribute(int id)
    {
        jumpTubeData = GlobalManager.Instance.specialAttributeDataManager.jumpAttrController.GetById( id );
    }


    void SaveSpecialAttribute()
    {
        GlobalManager.Instance.specialAttributeDataManager.jumpAttrController.AddSpecialAttr( jumpTubeData );
    }

}
