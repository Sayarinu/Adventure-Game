using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    SceneCode SC;
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneCode>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            SC.LoadNextScene();
        }
    }
}
