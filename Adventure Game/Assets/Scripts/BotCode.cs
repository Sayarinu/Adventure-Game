using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotCode : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;

    public Bullet bulletPrefab;
    public Vector3 bulletSpawnOffset = new Vector3(0, 0, 0);
    private float SpherecastRadius = 0.1f;

    public LayerMask mask;
    public float range = 10f;
    private RaycastHit hit;
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
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());

    }
    IEnumerator LookForPlayer() {
        while (true) {
            bool sight = HasLineOfSight();
            switch(enemyType){
                case 0:
                    _agent.speed=1;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(player.transform.position);
                    break;
                case 1:
                    _agent.speed=5;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(player.transform.position);
                    break;
                case 2:
                    _agent.speed=10;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(player.transform.position);
                    break;
                case 3:
                    _agent.speed=1;
                    yield return new WaitForSeconds(.5f);
                    print(HasLineOfSight());
                    if(!sight){
                        _agent.SetDestination(player.transform.position);
                    }else{
                        _agent.SetDestination(gameObject.transform.position);
                        
                    }
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

    private bool HasLineOfSight(){
        if(Physics.SphereCast(gameObject.transform.position + bulletSpawnOffset, SpherecastRadius, ((player.transform.position + bulletSpawnOffset) - (gameObject.transform.position + bulletSpawnOffset)).normalized, out hit, range, mask)){
           
            return hit.collider.tag == "Player";
        }
       
        return false;
    }

}
