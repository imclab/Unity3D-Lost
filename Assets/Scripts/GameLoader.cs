using UnityEngine;
using System.Collections;
using Com.Lost.GameData;

public class GameLoader : MonoBehaviour {
    public GUIText idText;
    SpaceFileItem space;

    void Awake() {
        if ( !GameManager.gameController.IsGameStarted ) {
            GameManager.StartGame();
        }
        GameManager.spaceCreator.InitSpace();
        space = GameManager.gameController.GetNextSpace();
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if ( idText != null && space != null ) {
            idText.text = space.id;
        }

        if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
            GameManager.spaceController.SpaceJump( space, SpaceJumpDirection_t.Left );
            space = GameManager.gameController.GetNextSpace();
        } else if ( Input.GetKeyDown( KeyCode.RightArrow ) ) {
            GameManager.spaceController.SpaceJump( space, SpaceJumpDirection_t.Right );
            space = GameManager.gameController.GetNextSpace();
        } else if ( Input.GetKeyDown( KeyCode.UpArrow ) ) {
            GameManager.spaceController.SpaceJump( space, SpaceJumpDirection_t.Up );
            space = GameManager.gameController.GetNextSpace();
        } else if ( Input.GetKeyDown( KeyCode.DownArrow ) ) {
            GameManager.spaceController.SpaceJump( space, SpaceJumpDirection_t.Down );
            space = GameManager.gameController.GetNextSpace();
        }
	
	}


  
}
