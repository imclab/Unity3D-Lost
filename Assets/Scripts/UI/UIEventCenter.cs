using UnityEngine;
using System.Collections;

public class UIEventCenter : MonoBehaviour {

    void BTE_StartGame_MainScene()
    {
        GameManager.runTimeGameControl.ShowBegan();
    }

}
