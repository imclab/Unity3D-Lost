using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorTest : EditorWindow {
    [MenuItem( "Game Tools/TestEditor" )]
    static void Active()
    {
        EditorWindow.GetWindow<EditorTest>( false );
    }

    void OnGUI()
    {
        if ( GUILayout.Button( "Test" ) )
        {
            foreach ( GameObject obj in GameObject.FindObjectsOfType<GameObject>() )
            {
                obj.SendMessage( "Haha",SendMessageOptions.DontRequireReceiver );
            }
        }

    }

    
    
}
