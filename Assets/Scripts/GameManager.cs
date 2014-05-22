using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static private GameController _gameController = null;
    static public GameController gameController {
        get {
            if ( _gameController == null ) {
                _gameController = new GameController();
            }
            return _gameController;
        }
    }


    static private SpaceController _spaceController = null;
    static public SpaceController spaceController {
        get {
            if ( _spaceController == null ) {
                _spaceController = new SpaceController();
            }
            return _spaceController;
        }
    }


    static private SpaceCreator _spaceCreator = null;
    static public SpaceCreator spaceCreator {
        get{
            if( _spaceCreator == null ){
                GameObject obj = new GameObject();
                obj.name = "GlobalGameObject";
                DontDestroyOnLoad(obj);

                _spaceCreator = obj.AddComponent<SpaceCreator>();
            }
            return _spaceCreator;
        }
    }

}



}
