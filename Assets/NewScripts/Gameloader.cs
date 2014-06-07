using UnityEngine;
using System.Collections;

public class Gameloader : MonoBehaviour {

	// Use this for initialization
	void Awake() {
        StartCoroutine( LoadingAnimation() );
        GlobalManager.Instance.StartGame();
    } 
	


    IEnumerator LoadingAnimation()
    {

        yield return 0;
    }



}
