using UnityEngine;
using System.Collections;

public class RunTimeGameControl : MonoBehaviour {

    public void ShowBegan()
    {
        StartCoroutine( PlayingGame() );
    }


    IEnumerator PlayingGame()
    {
        // camera fade out
        yield return new WaitForSeconds( 0.5f );
        Application.LoadLevel( "GamePlay" );
        GameManager.spaceCreator.InitSpace();
    }
}
