using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    SceneCode SC;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        SC = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneCode>();
    }

    // Update is called once per frame
    public void GameStart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
