using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearWall : MonoBehaviour
{
    public int lifetime;
    public int fadeDuration=2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime);

    }

 

    // Update is called once per frame
}
