/*
================================================================================
FileName    : 
Description : 脚本挂载于Camera
Date        : 2014-05-27
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;

public class CameraFade : MonoBehaviour {
    public float fadeTime = 0.8f;

    private GameObject _cameraCube;

    void Awake()
    {
        SetAnimationCurve();
    }

    /// <summary>
    /// 摄像机淡出,屏幕变黑色
    /// </summary>
    void CameraOut()
    {
        _cameraCube.animation.Play( "CameraOut" );
    }


    /// <summary>
    /// 摄像机谈入,屏幕变回原有图像
    /// </summary>
    void CameraIn()
    {
        _cameraCube.animation.Play( "CameraIn" );
    }




    void SetAnimationCurve()
    {
        CreateCameraCube();

        _cameraCube.AddComponent<Animation>();
        AnimationCurve curve_CameraIn = AnimationCurve.EaseInOut( 0, 1, fadeTime, 0 );      // camera in
        AnimationCurve curve_CameraOut = AnimationCurve.EaseInOut( 0, 0, fadeTime, 1 );     // camera out
        AnimationClip clip;
        clip = new AnimationClip();
        clip.SetCurve( "", typeof( Material ), "_Color.a", curve_CameraIn );
        _cameraCube.animation.AddClip( clip, "CameraIn" );

        clip = new AnimationClip();
        clip.SetCurve( "", typeof( Material ), "_Color.a", curve_CameraOut );
        _cameraCube.animation.AddClip( clip, "CameraOut" );
    }
    


    void CreateCameraCube()
    {
        _cameraCube = GameObject.CreatePrimitive( PrimitiveType.Quad );
        _cameraCube.transform.localScale = new Vector3( 100, 100, 1 );
        _cameraCube.renderer.material = new Material( Shader.Find( "Transparent/Diffuse" ) );
        _cameraCube.renderer.material.color = new Color(0,0,0,0);
        _cameraCube.transform.parent = transform;
        _cameraCube.transform.localPosition = new Vector3( 0, 0, 1f );
        _cameraCube.transform.localRotation = Quaternion.identity;
    }


/*
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.UpArrow ) )
        {
            CameraIn();
        }

        if ( Input.GetKeyDown( KeyCode.DownArrow ) )
        {
            CameraOut();
        }
    }
*/

}
