using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotCode : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject enemy;

    public int enemyType;
    /*
    0 - default charger
    1 - faster charger
    2 - zooming charger (usually goes too fast to hit if you dodge bc inertia)
    3 - shooter
    4 - circler
    5 - tank
    */
    NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());
    }
    IEnumerator LookForPlayer() {
        while (true) {
            switch(enemyType){
                case 0:
                    _agent.speed=1;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(enemy.transform.position);
                    break;
                case 1:
                    _agent.speed=5;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(enemy.transform.position);
                    break;
                case 2:
                    _agent.speed=10;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(enemy.transform.position);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
