#define DEBUGMODE
using UnityEngine;
using System.Collections;
public class RunTimeGameControl : MonoBehaviour {
   
    private bool canControl = false;


#if !DEBUGMODE
    void Awake()
    {
        // 加载所有的游戏数据
        GlobalManager.Instance.InitGameData( this, LoadDataOk );
    }
#endif

    
    /// <summary>
    /// 所有游戏数据载入完毕后的回调
    /// </summary>
    void LoadDataOk()
    {
        StartCoroutine( InitGameWorld() );
    }


    /// <summary>
    /// 游戏世界所有元素初始化完后的回调
    /// </summary>
    void InitGameWorldOk()
    {
        // Camera fade in
        canControl = true;
    }


    /// <summary>
    /// 载入空场景,初始化指定的游戏世界
    /// </summary>
    /// <returns></returns>
    IEnumerator InitGameWorld()
    {
        yield return LoadScene();
        int id = GlobalManager.Instance.gameController.gameConfigure.NEXTWORLDID;
        GlobalManager.Instance.gameWorldCreator.CreateGameWorld( id, InitGameWorldOk );
    }

    
    /// <summary>
    /// 清除当前游戏世界元素,重新载入空场景
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadScene()
    {
        // Camera Fade out
        Application.LoadLevel( "GamePlayScene" );
        yield return 0;
    }


    /// <summary>
    /// 通过传送点跳跃到其他游戏世界 --> 设置下一个游戏世界ID,根据ID重新初始化整个游戏世界 
    /// </summary>
    /// <param name="id"></param>
    public void JumpToNewGameWorld( int id )
    {
        canControl = false;
        GlobalManager.Instance.gameController.gameConfigure.NEXTWORLDID = id;
        InitGameWorld();
    }



    public void GamePause()
    {
        
    }

    public void GameResume()
    {
        
    }



}
