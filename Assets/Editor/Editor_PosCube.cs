using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DragMove))]
public class Editor_PosCube : Editor
{

    void OnSceneGUI()
    {
        if (Event.current.type == EventType.mouseDown)
        {
            Debug.Log("Down");
        }

        if (Event.current.type == EventType.mouseUp)
        {
            GameObject obj = Selection.activeGameObject;
            bool isAvailablePos = true;
            if (obj && obj.CompareTag("Ground"))
            {
                Debug.Log("Change");
                Vector3 sp = obj.transform.position;
                Vector3 targetPos = new Vector3(Mathf.RoundToInt(sp.x), Mathf.RoundToInt(sp.y), Mathf.RoundToInt(sp.z));
                /*
                foreach (Collider collider in Physics.OverlapSphere(targetPos, 0.5f))
                {
                    if (collider.gameObject != obj)
                    {
                        isAvailablePos = false;
                    }
                }
                */

                if (isAvailablePos)
                {
                    obj.transform.position = targetPos;
                }
                else
                {

                }
                

            }
        }
        
    }
}

