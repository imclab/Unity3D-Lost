using UnityEngine;
using System.Collections;

public class JumpTube : MonoBehaviour
{
    public MJumpTube jumpTubeData;

    void InitSpecialAttribute()
    {
        int id = GetComponent<BaseItem>().baseData.ID;
        jumpTubeData = SpecialAttributeManager.jumpAttrController.GetById( id );
    }


    void SaveSpecialAttribute()
    {
        SpecialAttributeManager.jumpAttrController.AddSpecialAttr( jumpTubeData );
    }

}
