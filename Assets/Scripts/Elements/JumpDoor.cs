﻿using UnityEngine;
using System.Collections;

public class JumpDoor : MonoBehaviour {
    public SpaceJumpDirection_t direction;
    private float rotateSpeed = 20;
    private float _dir = 1;


    void Start() {
        _dir = Random.value > 0.5f ? 1 : -1;
    }

    void Update() {
        transform.eulerAngles += new Vector3(0,0,rotateSpeed * _dir * Time.deltaTime);
    }

    void OnTriggerEnter2D( Collider2D obj ) {
        if( obj.CompareTag( "Player" ) ) {
            GetComponent<SpriteRenderer>().color = new Color( 1, 0, 0 );
        }
    }

    void OnTriggerExit2D( Collider2D obj ) {
        if( obj.CompareTag( "Player" ) ) {
            GetComponent<SpriteRenderer>().color = new Color( 1, 1, 1 );
        }
    }






    // ------------------------------- Attribute operation -----------------------------
    [ExecuteInEditMode]
    void SaveMyAttribute(int id) {
        JumpDoorAttribute jumpDoorAttr = new JumpDoorAttribute();
        switch( direction ) {
            case SpaceJumpDirection_t.Left:
                jumpDoorAttr.dir = 0;
                break;
            case SpaceJumpDirection_t.Right:
                jumpDoorAttr.dir = 1;
                break;
            case SpaceJumpDirection_t.Up:
                jumpDoorAttr.dir = 2;
                break;
            case SpaceJumpDirection_t.Down:
                jumpDoorAttr.dir = 3;
                break;
        }

        ElementAtrribute elementAttribute = new ElementAtrribute();
        elementAttribute.id = id;
        elementAttribute.attributeJsonStr = JsonFx.Json.JsonWriter.Serialize( jumpDoorAttr );
        GameManager.attributeSystem.AddElementAttribute( elementAttribute );
    }

    [ExecuteInEditMode]
    void LoadMyAttribute( int id )
    {
        ElementAtrribute elementAttribute = GameManager.attributeSystem.GetAttributeStrByID( id );
        if ( elementAttribute == null )
        {
            Debug.LogWarning( "Get Attribute faild" );
            return;
        }
        JumpDoorAttribute attr = JsonFx.Json.JsonReader.Deserialize<JumpDoorAttribute>( elementAttribute.attributeJsonStr );

        switch ( attr.dir )
        {
            case 0:
                direction = SpaceJumpDirection_t.Left;
                break;
            case 1:
                direction = SpaceJumpDirection_t.Right;
                break;
            case 2:
                direction = SpaceJumpDirection_t.Up;
                break;
            case 3:
                direction = SpaceJumpDirection_t.Down;
                break;
        }
    }
}


