using UnityEngine;
using System.Collections;

public class PlayerSystem : MonoBehaviour {
    private SpaceJumpDirection_t nextDir = SpaceJumpDirection_t.None;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void SpaceJump()
    {
        if ( nextDir == SpaceJumpDirection_t.None )
        {
            return;
        }

        GameManager.spaceController.SpaceJump( nextDir );
    }



    void ReadyToSpaceJump( SpaceJumpDirection_t dir )
    {
        if ( nextDir != dir )
        {
            nextDir = dir;
        }
    }

    void CancelToSpaceJump( SpaceJumpDirection_t dir )
    {
        if ( nextDir == dir )
        {
            nextDir = SpaceJumpDirection_t.None;
        }
    }




}
