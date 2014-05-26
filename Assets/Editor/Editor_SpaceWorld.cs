using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using JsonFx.Json;
public class Editor_SpaceWorld : EditorWindow {
    static private string id = "";
    static private bool isOpen = false;
    
    [MenuItem("Game Tools/Space World Editor")]
    static void Active() {
        EditorWindow.GetWindow<Editor_SpaceWorld>( false );
    }


    void OnGUI() {
        DrawMainPanel();
    }

    void DrawMainPanel() {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label( "File ID: ",  GUILayout.Width(40),GUILayout.Height( 20 ) );
        id = GUILayout.TextField( id, GUILayout.Height( 20 ) );
        GUILayout.EndHorizontal();
        GUILayout.Label( "" );
        GUILayout.BeginHorizontal();
        if ( GUILayout.Button( "Open Space" , GUILayout.Height(20)) ) {
            if ( id == "" ) {
                return;
            }

            if ( isOpen ) {
                if ( !EditorUtility.DisplayDialog( "Warning!", "Some spaceworld has opend, Would you want to clear it?", "Yes", "Cancel" ) ) {
                    return;
                }

                Clear();
                OpenSpaceWorld( id );

            } else {
                OpenSpaceWorld( id );
            }
        }

        if ( GUILayout.Button( "Save Space",  GUILayout.Height( 20 ) ) ) {
            if ( id == "" ) {
                return;
            }

            SaveSpaceWorld( id );
        }

        GUILayout.EndHorizontal();

        GUILayout.Label( "" );
        GUILayout.Label( "" );
        if ( GUILayout.Button( "Clear" ,GUILayout.Height(20)) ) {
            Clear();
        }

        GUILayout.EndVertical();
    }



    void Clear() {
        isOpen = false;
        GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
        foreach ( GameObject obj in objs ) {
            if ( obj.layer == LayerMask.NameToLayer( "Saved" ) ) {
                DestroyImmediate( obj );
            }
        }
    }


    void OpenSpaceWorld( string id ) {
        GameManager.attributeSystem.LoadAllAttribute();
        string filePath = Application.streamingAssetsPath + "/SpaceWorlds/" + ConstantParams.file_space + id;

        if ( !File.Exists( filePath ) ) {
            if ( !EditorUtility.DisplayDialog( "Warning!", ConstantParams.file_space + id + ".xml doesn't exists, You want create it?", "Yes", "Cancel" ) ) {
                Debug.Log( "Do not create new space world" );
                return;
            }
        } else {
            string spaceWorldDataStr = DataCenter.LoadDataFromFile( Application.streamingAssetsPath + "/SpaceWorlds/", ConstantParams.file_space + id, false );
            SpaceWorld space = JsonReader.Deserialize<SpaceWorld>(spaceWorldDataStr);

            foreach ( SpaceItem item in space.items ) {
                GameObject obj = Instantiate( Resources.Load( item.item_name ) ) as GameObject;
                obj.name = item.item_name + "_" + item.uid;
                obj.transform.position = new Vector3(item.item_pos.x,item.item_pos.y,item.item_pos.z);
                obj.transform.rotation = new Quaternion( item.itme_rot.x, item.itme_rot.y, item.itme_rot.z, item.itme_rot.w );
                obj.transform.localScale = new Vector3( item.item_scale.x, item.item_scale.y, item.item_scale.z );
                
                obj.SetActive( item.isActive );
            }
        }

        isOpen = true;      
    }


    /// <summary>
    /// 保存所有属于 Saved 层的物体
    /// </summary>
    /// <param name="id"></param>
    void SaveSpaceWorld( string id ) {

        string filePath = Application.streamingAssetsPath + "/SpaceWorlds/" + ConstantParams.file_space + id;
#if LR_DEBUG
        Debug.Log("<color=green>" + filePath + "</color>");
#endif
        if( File.Exists(filePath )){
            if( !EditorUtility.DisplayDialog("Warning!","Space world has already exists, You want overide it?","Ok","Cancel")){
                return;
            } 
        }


        SpaceWorld space = new SpaceWorld();

        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject>savedItems = new List<GameObject>();

        foreach ( GameObject obj in objects ) {
            if ( obj.layer != LayerMask.NameToLayer( "Saved" ) ) {
                continue;
            }
            savedItems.Add( obj );
            Debug.Log( obj.name );
        }


        space.items = new SpaceItem[savedItems.Count];
        for ( int i = 0; i < savedItems.Count; ++i ) {
            SpaceItem item = new SpaceItem();
            item.uid = GameManager.attributeSystem.GetUniqueID();
            item.item_name = savedItems[i].name.Split('_')[0];
            item.isActive = savedItems[i].activeSelf;
            item.item_pos = new LRVector3( savedItems[i].transform.position.x, savedItems[i].transform.position.y, savedItems[i].transform.position.z );
            item.itme_rot = new LRQuaternion( savedItems[i].transform.rotation.x, savedItems[i].transform.rotation.y, savedItems[i].transform.rotation.z, savedItems[i].transform.rotation.w );
            item.item_scale = new LRVector3( savedItems[i].transform.localScale.x, savedItems[i].transform.localScale.y, savedItems[i].transform.localScale.z );
            space.items[i] = item;
            
            savedItems[i].SendMessage( "SaveMyAttribute", SendMessageOptions.DontRequireReceiver );
        }

        string spaceWorldDataStr = JsonWriter.Serialize( space );
        DataCenter.SaveDataToFile( spaceWorldDataStr, Application.streamingAssetsPath + "/SpaceWorlds/", ConstantParams.file_space + id, false );
        GameManager.attributeSystem.SaveAllAttribute();
        AssetDatabase.Refresh();
    }





}
