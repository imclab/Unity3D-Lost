using UnityEngine;
using System.Collections;

public class DragMove : MonoBehaviour {
    public float dragSpeed = 1;
    static private Transform current = null;
    private bool isDragMove = false;

    Transform myTrans = null;
    Transform cameraTrans = null;
    Vector3 mousePos = Vector3.zero;
    Vector3 subPos = Vector3.zero;

	// Use this for initialization
	void Start () {
        myTrans = transform;
        cameraTrans = Camera.main.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isDragMove)
        {
            mousePos = cameraTrans.camera.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0, 0, cameraTrans.position.z) - subPos;
            myTrans.position = Vector3.MoveTowards(myTrans.position, mousePos, dragSpeed);
        }
        
	
	}

    
    void OnMouseDown()
    {
        if (current == null)
        {
            current = myTrans;
            isDragMove = true;
            mousePos = cameraTrans.camera.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0, 0, cameraTrans.position.z);
            subPos = mousePos - myTrans.position;
            Debug.Log("Hit");
        }
    }

    void OnMouseUp()
    {
        if (current == myTrans)
        {
            current = null;
            isDragMove = false;
        }
    }

}
