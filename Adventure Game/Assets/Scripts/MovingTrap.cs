using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [SerializeField]
    Transform pos1, pos2;
    [SerializeField]
    bool pos1Target = true;
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float switchDist = .5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 currTarget;
        if (pos1Target) {
            currTarget = pos1.position;
        } else {
            currTarget = pos2.position;
        }
        this.transform.position = Vector3.MoveTowards(transform.position, currTarget, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currTarget) < switchDist) {
            pos1Target = !pos1Target;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerCode>().TakeDamage(10);
        }
    }
}
