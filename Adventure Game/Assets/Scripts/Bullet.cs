using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 5f;
    public float moveSpeed = 2f;
    public Rigidbody Rigidbody;

    public PlayerCode playerCode;

    private void Awake(){
        Rigidbody = GetComponent<Rigidbody>();
        playerCode = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCode>();
    }
    // Start is called before the first frame update
    private void OnEnable() {
        CancelInvoke("Disable");
        Invoke("Disable",destroyTime);
    }

    private void OnTriggerEnter(Collider other) {
        switch(other.tag){
            case "Player":
                playerCode.TakeDamage();
                Disable();
                break;
            default:
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Disable(){
        CancelInvoke("Disable");
        Rigidbody.velocity = Vector3.zero;
        Destroy(gameObject);
    }
}
