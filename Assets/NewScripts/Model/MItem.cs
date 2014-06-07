/*
================================================================================
FileName    : 
Description s: 
Date        : 2014-06-07
Author      : ss0x53
Version     : 
================================================================================
*/
using UnityEngine;
using System.Collections;

public class MItem  {
    private int id;
    private string name;
    private Vector3 pos;
    private Vector3 rot;
    private Vector3 scale;


    /// <summary>
    /// ID可以根据关卡ID*10及序列化时当前物体的索引数作为其当前关卡中
    /// </summary>
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
