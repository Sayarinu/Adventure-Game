using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearWall : MonoBehaviour
{
    public int lifetime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Disappear");
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
