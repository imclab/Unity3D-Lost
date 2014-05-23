using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Xml;
using System.IO;

public class Editor_SpaceWorld : EditorWindow {
    static private string id = "";
    
    [MenuItem("Game Tools/Space World Editor")]
    static void Active() {
        EditorWindow.GetWindow<Editor_SpaceWorld>( true );
    }


    void OnGUI() {
        DrawMainPanel();
    }

    void DrawMainPanel() {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label( "ID ", GUILayout.Width( 20 ), GUILayout.Height( 20 ) );
        id = GUILayout.TextField( id, GUILayout.Width( 140 ), GUILayout.Height( 20 ) );
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if ( GUILayout.Button( "Open Space" , GUILayout.Width(80),GUILayout.Height(20)) ) {
            if ( id == "" ) {
                return;
            }

            OpenSpaceWorld( id );
        }

        if ( GUILayout.Button( "Save Space", GUILayout.Width( 80 ), GUILayout.Height( 20 ) ) ) {
            if ( id == "" ) {
                return;
            }

            SaveSpaceWorld( id );
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }



    void OpenSpaceWorld( string id ) {
        string filePath = Application.streamingAssetsPath + "/SpaceWorlds/" + ConstantParams.file_space + id + ".dat";

        if ( !File.Exists( filePath ) ) {
            if ( !EditorUtility.DisplayDialog( "Warning!", ConstantParams.file_space + id + ".dat doesn't exists, You want create it?", "Yes", "Cancel" ) ) {
                Debug.Log( "Do not create new space world" );
                return;
            }
        }

        Debug.Log( "Create new space world" );
        
    }


    /// <summary>
    /// 保存所有属于 Saved 层的物体
    /// </summary>
    /// <param name="id"></param>
    void SaveSpaceWorld( string id ) {

        string filePath = Application.streamingAssetsPath + "/SpaceWorlds/" + ConstantParams.file_space + id + ".dat";
#if LR_DEBUG
        Debug.Log("<color=green>" + filePath + "</color>");
#endif
        if( File.Exists(filePath )){
            if( !EditorUtility.DisplayDialog("Warning!","Space world has already exists, You want overide it?","Ok","Cancel")){
                return;
            }
        }


        SpaceWorld space = new SpaceWorld();
        space.spaceId = int.Parse( id );

        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();

        foreach ( GameObject obj in objects ) {
            if ( obj.layer != LayerMask.NameToLayer( "Saved" ) ) {
                continue;
            }

            SpaceItem item = new SpaceItem();
            item.item_name = obj.name;
            item.isActive = obj.activeSelf;
            item.item_pos = obj.transform.position;
            item.item_rot = obj.transform.rotation;
            item.item_scale = obj.transform.localScale;

            space.items.Add( item );
        }

        string spaceWorldData = SerializeSpaceWorldToXml( space );
        DataCenter.SaveDataToFile(spaceWorldData,Application.streamingAssetsPath + "/SpaceWorlds/", ConstantParams.file_space + id + ".xml",false);
        AssetDatabase.Refresh();
    }


    string SerializeSpaceWorldToXml(SpaceWorld space) {
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement( "SpaceWorld" );
        xmlDoc.AppendChild( root );

        XmlElement worldItem = xmlDoc.CreateElement( "SpaceID" );
        worldItem.InnerText = space.spaceId.ToString();
        root.AppendChild( worldItem );

        worldItem = xmlDoc.CreateElement( "SpaceItems" );
        root.AppendChild( worldItem );

        foreach ( SpaceItem item in space.items ) {
            XmlElement spaceItem = xmlDoc.CreateElement( "SpaceItem" );
            worldItem.AppendChild( spaceItem );

            XmlElement element;
            
            element = xmlDoc.CreateElement( "item_name" );
            element.InnerText = item.item_name;
            spaceItem.AppendChild( element );

            element = xmlDoc.CreateElement( "isActive" );
            element.InnerText = item.isActive ? "1" : "0";
            spaceItem.AppendChild( element );

            element = xmlDoc.CreateElement( "item_pos" );
            element.InnerText = string.Format( "{0}_{1}_{2}", item.item_pos.x, item.item_pos.y, item.item_pos.z );
            spaceItem.AppendChild( element );

            element = xmlDoc.CreateElement( "item_rot" );
            element.InnerText = string.Format( "{0}_{1}_{2}", item.item_rot.x, item.item_rot.y, item.item_rot.z );
            spaceItem.AppendChild( element );

            element = xmlDoc.CreateElement( "item_scale" );
            element.InnerText = string.Format( "{0}_{1}_{2}", item.item_scale.x, item.item_scale.y, item.item_scale.z );
            spaceItem.AppendChild( element );
        }

#if LR_DEBUG
        Debug.Log("<color=green>Editor_SpaceWorld.cs:\n</color>" + xmlDoc.InnerXml);
#endif

        return xmlDoc.InnerXml;
        
    }

}
