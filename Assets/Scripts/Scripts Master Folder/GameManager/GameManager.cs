using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public Slider progressBar;
    public bool gamePaused = false;
   


    private void Awake()
    {
        instance = this;
        LevelChanger.onChangeScene += LoadNewScene;

        //Loads the first scene ADDATIVELY to the Persistent Scene. Keep in mind the Persistent scene is a "Director" of sorts for scene control
        SceneManager.LoadSceneAsync((int)SceneIndexes.MAINMENU, LoadSceneMode.Additive);
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();



    public void LoadNewScene(int currentScene, int sceneIndexDestination)
    {
        loadingScreen.SetActive(true);
        

        scenesLoading.Add(SceneManager.UnloadSceneAsync(currentScene));
        //Debug.Log("Deleted Scene: " + SceneManager.GetSceneAt(currentScene).ToString());
        scenesLoading.Add(SceneManager.LoadSceneAsync(sceneIndexDestination, LoadSceneMode.Additive));
    
        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadGame()
    {
        loadingScreen.SetActive(true);
        
        
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAINMENU));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.DEV_ROOM, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());

    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        //For every scene that is loading...
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            //While x scene is not finished loading...
            while(!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                progressBar.value = Mathf.RoundToInt(totalSceneProgress);
                //Return null until its done then go to the next loading scene
                yield return null;
            }
            
        }
        // when each scene is finished loading, set loadScreen visual to false (Unveil the curtains)

        loadingScreen.gameObject.SetActive(false);

    }


}
