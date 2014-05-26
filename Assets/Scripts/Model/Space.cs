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
using Com.Lost.GameData;

/// <summary>
/// 每一个空间世界,由一个ID和对应的文件名,及空间元素组成
/// </summary> 
    [System.Serializable]
    public class SpaceWorld {
        public SpaceWorld(){}
        public SpaceItem[] items;
    }


    [System.Serializable]
    public class SpaceItem {
        public SpaceItem(){}
        public string  item_name;
        public bool isActive;

        public LRVector3 item_pos;
        public LRQuaternion itme_rot;
        public LRVector3 item_scale;
        
        
    }

    [System.Serializable]
    public class LRVector3 {
        public LRVector3() { }
        public LRVector3( float x = 0, float y = 0, float z = 0 ) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float x;
        public float y;
        public float z;
    }

  [System.Serializable]
    public class LRQuaternion {
      public LRQuaternion() { }
      public LRQuaternion( float x = 0, float y = 0, float z = 0, float w = 0 ) {
          this.x = x;
          this.y = y;
          this.z = z;
          this.w = w;
      }

      public float x;
      public float y;
      public float z;
      public float w;
    }




