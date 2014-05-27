using UnityEngine;
using System.Collections;

public class RunTimeGameControl : MonoBehaviour {

    

    public void ShowBegan()
    {
        
        StartCoroutine( PlayingGame() );
    }


    IEnumerator PlayingGame()
    {
        Camera.main.SendMessage( "CameraOut" ,SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds( 1 );

        Application.LoadLevel( "GamePlay" );
        yield return null;
    }

   

}
