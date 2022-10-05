using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform PlayerTrans;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - PlayerTrans.position;
    }

    private void LateUpdate() {
        transform.position = PlayerTrans.position + offset;
    }
}
