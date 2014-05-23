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
using System.Collections.Generic;


    public class SpaceWorld {
        public int spaceId;
        public List<SpaceItem> items = new List<SpaceItem>();
    }


    public class SpaceItem {
        public string  item_name;
        public bool isActive;
        public Vector3 item_pos;
        public Quaternion item_rot;
        public Vector3 item_scale;
    }

