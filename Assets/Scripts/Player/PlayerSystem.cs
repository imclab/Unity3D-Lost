using UnityEngine;
using System.Collections;

public class PlayerSystem : MonoBehaviour {
    [SerializeField]
    private SpaceJumpDirection_t nextDir = SpaceJumpDirection_t.None;

	void Start () {

        Camera.main.SendMessage( "CameraIn" ,SendMessageOptions.DontRequireReceiver);
        ResetMyPos();

	}

    void ResetMyPos()
    {
        float[] posX = new float[4];
        foreach( GameObject obj in GameObject.FindGameObjectsWithTag( "JumpDoor" ) )
        {
            switch( obj.GetComponent<JumpDoor>().direction )
            {
                case SpaceJumpDirection_t.Left:
                    posX[0] = obj.transform.position.x;
                    break;
                case SpaceJumpDirection_t.Right:
                    posX[1] = obj.transform.position.x;
                    break;
                case SpaceJumpDirection_t.Up:
                    posX[2] = obj.transform.position.x;
                    break;
                case SpaceJumpDirection_t.Down:
                    posX[3] = obj.transform.position.x;
                    break;
            }
        }


        switch( GameManager.spaceController.lastChoiceDir )
        {
            case SpaceJumpDirection_t.Left:
                transform.position = new Vector3(posX[1],transform.position.y,transform.position.z);
                break;
            case SpaceJumpDirection_t.Right:
                transform.position = new Vector3(posX[0],transform.position.y,transform.position.z);
                break;
            case SpaceJumpDirection_t.Up:
                transform.position = new Vector3(posX[3],transform.position.y,transform.position.z);
                break;
            case SpaceJumpDirection_t.Down:
                transform.position = new Vector3(posX[2],transform.position.y,transform.position.z);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if( Input.GetKeyDown( KeyCode.J ) )
        {
            StartCoroutine( SpaceJump());
        }
	}



    IEnumerator SpaceJump()
    {
        if( nextDir != SpaceJumpDirection_t.None )
        {
            Camera.main.SendMessage( "CameraOut" ,SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds( 1f );
            GameManager.spaceController.SpaceJump( nextDir );
        }
    }



    void ReadyToSpaceJump( SpaceJumpDirection_t dir )
    {
        
            nextDir = dir;
        
    }

    void CancelToSpaceJump( SpaceJumpDirection_t dir )
    {
       
            nextDir = SpaceJumpDirection_t.None;
       
    }
    



}
