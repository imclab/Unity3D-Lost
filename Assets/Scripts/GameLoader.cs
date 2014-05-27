/*
================================================================================
FileName    : 
Description : First level you shold execute this script
Date        : 2014-05-27
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using Com.Lost.GameData;

public class GameLoader : MonoBehaviour {

    void Start()
    {
        // Maybe show some UI or animation
        StartCoroutine( LoadingUI() );
        StartCoroutine( StartGame() );
    }

    IEnumerator StartGame()
    {
        GameManager.gameController.StartGame();
        yield return null;
    }


    IEnumerator LoadingUI()
    {

        yield return null;
    }

  
}
