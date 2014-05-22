
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class Editor_InitProjectFolder  {
    static private string[] folders = {
                                       "Editor",
                                       "Scripts",
                                       "Textures",
                                       "Resources",
                                       "Objects",
                                       "StreamingAssets",
                                       "Materials",
                                       "Shaders",
                                       "UI",
                                       "Plugins",
                                   };


    [MenuItem("Game Tools/InitProjectFolder")]
    static void Active() {
        foreach ( string folder in folders) {
            if ( !Directory.Exists( Application.dataPath + "/" + folder ) ) {
                AssetDatabase.CreateFolder( "Assets", folder );
            }
        }
        
    }
}
