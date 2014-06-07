using UnityEngine;
using System.Collections;

public class GlobalManager  {
	static private GlobalManager _globalManager = null;
    static public GlobalManager Instance
    {
        get
        {
            if( _globalManager == null )
            {
                _globalManager = new GlobalManager();
            }
            return _globalManager;
        }
    }


    public void StartGame()
    {
        GameObject obj = new GameObject();
        obj.name = "RunTime_GlobalGameObject";
        _runTimeGameControl = obj.AddComponent<RunTimeGameControl>();
        GameObject.DontDestroyOnLoad( obj );
    }

    private RunTimeGameControl _runTimeGameControl = null;
    public RunTimeGameControl runTimeGameControl
    {
        get
        {
            if( _runTimeGameControl == null )
            {
                StartGame();
            }
            return _runTimeGameControl;
        }
    }


    public delegate void InitGameDataOverCallback();
    public void InitGameData(MonoBehaviour mono,InitGameDataOverCallback callback)
    {
        mono.StartCoroutine( ToInitGameData(mono,callback));
    }

    IEnumerator ToInitGameData( MonoBehaviour mono, InitGameDataOverCallback callback )
    {
        yield return mono.StartCoroutine(gameWorldController.LoadGameWorlds());
        yield return mono.StartCoroutine( specialAttributeDataManager.LoadAllSpecialAttribute( mono ) );
        yield return mono.StartCoroutine( gameController.LoadGameConfigure() );

        if( callback != null )
        {
            callback();
        }
        yield return 0;
    }


   



    private SpecialAttributeDataManager _specialAttributeDataManager = null;
    public SpecialAttributeDataManager specialAttributeDataManager
    {
        get
        {
            if( _specialAttributeDataManager == null )
            {
                _specialAttributeDataManager = new SpecialAttributeDataManager();
            }
            return _specialAttributeDataManager;
        }
    }



	private GameWorldCreator _gameWorldCreator = null;
    public GameWorldCreator gameWorldCreator
    {
        get
        {
            if( _gameWorldCreator == null )
            {
                _gameWorldCreator = new GameWorldCreator();
            }
            return _gameWorldCreator;
        }
    }


    private GameWorldDataManager _gameWorldDataManager = null;
    public GameWorldDataManager gameWorldController
    {
        get
        {
            if( _gameWorldDataManager == null )
            {
                _gameWorldDataManager = new GameWorldDataManager();
            }
            return _gameWorldDataManager;
        }
    }


    private GameController _gameController = null;
    public GameController gameController
    {
        get
        {
            if( _gameController == null )
            {
                _gameController = new GameController();
            }
            return _gameController;
        }
    }


}
