using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked = false;
    public string NextLevel;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            /*
            if (!locked) {
                SceneManger.LoadScene(NextLevel);
            } else if (PublicVars.hasKey[doorCode]) {
                PublicVars.hasKey[doorCode] = false;
                SceneManager.LoadScene(NextLevel);
            }
            */
        }
    }
}
