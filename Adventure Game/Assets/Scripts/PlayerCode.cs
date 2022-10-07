using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCode : MonoBehaviour
{
    // Start is called before the first frame update
    int bulletForce = 500;

    public GameObject bulletPrefab;
    NavMeshAgent _agent;

    Camera mainCam;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _agent.SetDestination(hit.point);
            }
        } else if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                transform.LookAt(hit.point);
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key")) {
            ChangeKeyCount(1);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Door")) {
            ChangeKeyCount(-1);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(){
        print("ow");
    }

    void ChangeKeyCount(int value) {
        PublicVars.keys += value;
    }
}
