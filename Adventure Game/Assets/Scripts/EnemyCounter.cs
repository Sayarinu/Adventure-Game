using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public int total;
    public int remaining;
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Enemy").Length;
        remaining = total;
        
    }

    // Update is called once per frame
    void Update()
    {
        remaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
        counter.text = "Enemies Left: " + remaining + "/" + total;
    }
}
