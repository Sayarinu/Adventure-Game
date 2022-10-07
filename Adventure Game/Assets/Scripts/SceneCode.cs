using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCode : MonoBehaviour
{
    [SerializeField]
    List<int> SceneIndexList;

    public void LoadNextScene() {
        Scene currScene = SceneManager.GetActiveScene();
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currScene);
        PublicVars.currScenePos++;
        SceneManager.LoadSceneAsync(SceneIndexList[PublicVars.currScenePos]);
    }

    public void ReloadScene() {
        Scene currScene = SceneManager.GetActiveScene();
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currScene);
        SceneManager.LoadSceneAsync(currScene.buildIndex);
    }
}
