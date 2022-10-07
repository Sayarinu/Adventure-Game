using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int health = 10;
    int bulletForce = 500;

    public GameObject bulletPrefab;
    NavMeshAgent _agent;
    SceneCode SC;

    Camera mainCam;
    bool isInvincible;

    [SerializeField]
    private float invincibilityDurationSeconds=1.5f;
    private float invincibilityDeltaTime=0.15f;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        SC = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneCode>();
        PublicVars.killed = 0;
        switch(SceneManager.GetActiveScene().name) {
            case "Level 1":
                PublicVars.enemies = PublicVars.enemies1;
                break;
            case "Level 2":
                PublicVars.enemies = PublicVars.enemies2;
                break;
            case "Level 3":
                PublicVars.enemies = PublicVars.enemies3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _agent.speed=2;
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
        if (PublicVars.killed == PublicVars.enemies) {
            SC.LoadNextScene();
        }

        if(Input.GetKey(KeyCode.Backspace)){
            Application.Quit();
        }
        Debug.Log(PublicVars.killed);

    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key")) {
            ChangeKeyCount(1);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Door")) {
            if (PublicVars.keys > 0) {
                ChangeKeyCount(-1);
                Destroy(other.gameObject);
            }
        }
        
    }

    public void TakeDamage(int dmg = 1){
        if(isInvincible){
            return;
        }
        health -= dmg;
        
        if (health <= 0) {
            SC.ReloadScene();
        }
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    void ChangeKeyCount(int value) {
        PublicVars.keys += value;
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
   
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");

        isInvincible = false;
    }
}
