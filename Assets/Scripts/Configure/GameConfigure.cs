using UnityEngine;
using System.Collections;

public class GameConfigure {

    public bool isFirstGameTime;

    /// <summary>
    /// 所以有空间ID,以二进制一维数组的形式存放
    /// </summary>
    public byte[] spaceMapMatrix;

    /// <summary>
    /// 下一个将要进入的空间的ID
    /// </summary>
    public int nextSpaceId;
}
