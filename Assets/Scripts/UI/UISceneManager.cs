using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneManager : MonoBehaviour
{
    static public UISceneManager instance;
    public GameObject uiScene;
    public GameObject inGameScene;

    public void Start()
    {
        
    }
    public void StartButtonClick()
    {
        //uiScene.SetActive(false);
        inGameScene.SetActive(true);
    }
}
