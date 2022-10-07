using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;


public class BotCode : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;

    public Bullet bulletPrefab;
    public Vector3 bulletSpawnOffset = new Vector3(0, 0, 0);
    private float SpherecastRadius = 0.1f;
    public BulletPool pool;
    public LayerMask mask;
    public float range = 10f;
    private RaycastHit hit;
    public int enemyType;
    public GameObject bullet;

    public float distance = 0;
    public Vector3 dir;

    private PlayerCode playerCode;
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
        pool = gameObject.GetComponent<BulletPool>();
        playerCode = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCode>();
        StartCoroutine(LookForPlayer());
        


    }

    private void Update() {
        distance = Vector3.Distance (transform.position, player.transform.position);
        _agent.updateRotation = false;
        gameObject.transform.rotation =  Quaternion.LookRotation(dir);
        
    }
    IEnumerator LookForPlayer() {
        while (true) {
            bool sight = HasLineOfSight();

            switch(enemyType){
                case 0:
                    _agent.speed=1;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(player.transform.position);
                    dir = _agent.velocity.normalized;
                    break;
                case 1:
                    _agent.speed=2;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(player.transform.position);
                    dir = _agent.velocity.normalized;
                    break;
                case 2:
                    _agent.speed=3;
                    yield return new WaitForSeconds(.5f);
                    _agent.SetDestination(player.transform.position);
                    dir = _agent.velocity.normalized;
                    break;
                case 3:
                    _agent.speed=1;
                    if(!sight){
                        _agent.SetDestination(player.transform.position);
                        yield return new WaitForSeconds(.5f);
                        dir = _agent.velocity.normalized;
                    }else{
                        _agent.SetDestination(gameObject.transform.position);
                        yield return new WaitForSeconds(1f);
                        dir = ((gameObject.transform.position) - (player.transform.position)).normalized;
                        bullet = pool.GetPooledObject();
                        if(bullet != null){
                            bullet.transform.position = transform.position + bulletSpawnOffset;
                            Physics.IgnoreCollision(bullet.GetComponent<Collider>(),GetComponent<Collider>());
                            bullet.SetActive(true);
                        }
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

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            playerCode.TakeDamage();
        }
    }

    private bool HasLineOfSight(){
        if(Physics.SphereCast(gameObject.transform.position + bulletSpawnOffset, SpherecastRadius, ((player.transform.position + bulletSpawnOffset) - (gameObject.transform.position + bulletSpawnOffset)).normalized, out hit, range, mask)){
           
            return hit.collider.tag == "Player";
        }
       
        return false;
    }

}
