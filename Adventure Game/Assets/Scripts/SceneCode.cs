using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCode : MonoBehaviour
{
    [SerializeField]
    List<int> SceneIndexList;
    int currScenePos = 0;

    public void LoadNextScene() {
        Scene currScene = SceneManager.GetActiveScene();
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currScene);
        currScenePos++;
        SceneManager.LoadSceneAsync(SceneIndexList[currScenePos]);
    }

    public void ReloadScene() {
        Scene currScene = SceneManager.GetActiveScene();
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currScene);
        SceneManager.LoadSceneAsync(currScene.buildIndex);
    }
}
