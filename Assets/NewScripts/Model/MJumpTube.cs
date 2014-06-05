using UnityEngine;
using System.Collections;

[System.Serializable]
public class MJumpTube {
    private int id;
    public int nextWorldId;

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
