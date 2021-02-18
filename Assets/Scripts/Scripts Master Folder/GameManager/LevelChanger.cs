using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]private int currentScene;
    [SerializeField]private int sceneIndexDestination = 0;
    public static Action<int,int> onChangeScene; 

    void Awake()
    {
        //currentScene = SceneManager.GetActiveScene().buildIndex;

    }

    public void OnTriggerEnter(Collider collider)
    {
        onChangeScene(currentScene, sceneIndexDestination);
    }
}
