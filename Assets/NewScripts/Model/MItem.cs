using UnityEngine;
using System.Collections;

public class MItem  {
    private int id;
    private string name;
    private Vector3 pos;
    private Vector3 rot;
    private Vector3 scale;


    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string NAME
    {
        get { return name; }
        set { name = value; }
    }

    public Vector3 POS
    {
        get { return pos; }
        set { pos = value; }
    }

    public Vector3 ROT
    {
        get { return rot; }
        set { rot = value; }
    }

    public Vector3 SCALE
    {
        get { return scale; }
        set { scale = value; }
    }

}
