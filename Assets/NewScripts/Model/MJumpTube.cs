using UnityEngine;
using System.Collections;

[System.Serializable]
public class MJumpTube {
    private int id;
    public int nextWorldId;

    /// <summary>
    /// 此ID 就是物体基础属性中的ID
    /// </summary>
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public int NEXTWORLDID
    {
        get { return nextWorldId; }
        set { nextWorldId = value; }
    }
}
