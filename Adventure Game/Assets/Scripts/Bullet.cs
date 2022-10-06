using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 5f;
    public float moveSpeed = 2f;
    public Rigidbody Rigidbody;

    public PlayerCode playerCode;
    public GameObject player;

    private void Awake(){
        Rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCode = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCode>();
    }
    // Start is called before the first frame update
    private void OnEnable() {
        transform.LookAt(player.transform.position, Vector3.up);
        Rigidbody.AddForce(gameObject.transform.forward*moveSpeed, ForceMode.VelocityChange);
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
                Disable();
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
        gameObject.SetActive(false);
    }
}
