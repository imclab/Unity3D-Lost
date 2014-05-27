using UnityEngine;
using System.Collections;

public class ShowSpaceID : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine( GetSpaceID() );
	}

    IEnumerator GetSpaceID()
    {
        yield return new WaitForSeconds( 0.5f );
        GetComponent<UILabel>().text = GameManager.gameController.GetNextSpace().id;
    }
	
}
