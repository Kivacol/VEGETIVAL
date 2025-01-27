﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum EnemyStates {GUARD, MESS, CHASE,HURT,DEAD}

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyCtrl1 : MonoBehaviour
{
    public EnemyStates enemyStates;

    private NavMeshAgent agent;

    private Animator anim;

   

    [Header("Basic Setting")]
    public float sightRadius;

    public bool isGuard;

    public float speed;

    private GameObject attackTarget;

    bool isRun;

    public float attackRange;

    public bool isHit;

    public UICtrl uiCtrl;

    public int LP = 5;

    public bool Immortal;

    public GameObject Button;

    [Header("Mess State")]
    public float messRange;

    private Vector3 wayPoint;

    private float timeToChangeDirection;

    public GameObject clawpoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;

    //亂跑

    public bool randomWalkMode;
    public bool resetRandomWalk;
    public GameObject Fire;

    //
    public EnemyCheck enemyCheck;

    AudioSource audioSource;
    public AudioClip hurt;
    public AudioClip die;
    public AudioClip attack;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        speed = agent.speed;



        //StartCoroutine(RandomCoordinate());
        //Target = 获取物体;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Immortal = false;
        InvokeRepeating("SwitchStates", 0f, 1.5f);

        randomWalkMode = false;
        resetRandomWalk = true;
        effectToSpawn = vfx[0];
        //if(other.gameObject.name == "Fire")
    }

    void Update()
    {
        
        
        SwitchAnimeation();
    }

    void SwitchAnimeation()
    {
        anim.SetBool("Run", isRun);
        
    }

    void SwitchStates()
    {
        if (FoundPlayer())
        {
            enemyStates = EnemyStates.CHASE;
            //Debug.Log("找到Player");
        }

            switch (enemyStates)
        {
            case EnemyStates.GUARD:
                break;
            case EnemyStates.CHASE:

                agent.speed = speed;
                chasePlayer();
                if (TargetInAttackRange()) {
                    audioSource.PlayOneShot(attack);
                    anim.SetTrigger("T_isAttack");
                    //Debug.Log("攻擊");
                    Invoke("CheckHit", 1);
                    SpawnVFX();
                }
                
                break;
            case EnemyStates.MESS:

                isGuard = false;
                agent.speed = speed * 1.5f;

                if (Vector3.Distance(wayPoint, transform.position)<=agent.stoppingDistance)
                {
                    isRun = false;

                    GetNewWayPoint();
                }
                else
                {
                    isRun = true;
                    agent.destination = wayPoint;
                }

                break;
            case EnemyStates.HURT:
                break;
            case EnemyStates.DEAD:
                
                break;
        }
    }

    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);

        foreach(var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }

    void chasePlayer()
    {
        if(randomWalkMode == true && resetRandomWalk == true)
        {
            isRun = true;
            agent.destination = transform.position+new Vector3(Random.Range(-40.0f, 40.0f),0, Random.Range(-40.0f, 40.0f));
            resetRandomWalk = false;
            Invoke("resetRandomWalkDic", 0.3f);
        }
        else if (!FoundPlayer())
        {
            isRun = false;
            agent.destination = transform.position;
        }

        else
        {
            isRun = true;
            agent.destination = attackTarget.transform.position;
        }
    }

    bool TargetInAttackRange()
    {
        if (attackTarget != null)
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= attackRange;
        else
        {
            return false;
        }
    }

    private void CheckHit()
    {
        if (isHit == true)
        {
            //Debug.Log("擊中");
            uiCtrl.Damage();
        }
        else
        {
            //Debug.Log("沒擊中");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHit = true;
            
        }
        else if (other.gameObject.CompareTag("attack"))
        {
            Damage();
            //Debug.Log(other.gameObject.name);
            if (other.gameObject.name == "FireAttack(Clone)") {
                randomWalkMode = true;
                Fire.gameObject.SetActive(true);
                speed = 25f;
                Invoke("resetRandomWalkMode", 10);
            }
            //if (other.gameObject.name == "Fire")
            //{
            //    timeToChangeDirection -= Time.deltaTime;

            //    if (timeToChangeDirection <= 0)
            //    {
            //        ChangeDirection();
            //}


            //    Debug.Log("fire");
            //    agent.speed = speed * 1.5f;
            //    if (Vector3.Distance(wayPoint, transform.position) <= agent.stoppingDistance)
            //    {
            //        isRun = false;
            //        GetNewWayPoint();
            //    }
            //    else
            //    {
            //        isRun = true;
            //    }
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHit = false;
            
        }
    }

    public void Damage()
    {
        if (Immortal==true) {
            return;
        }
        audioSource.PlayOneShot(hurt);
        LP -= 1;
        Immortal = true;
        
        Invoke("CancelImmortal", 0.5f);
        HurtAnime();
        Debug.Log("受傷");

        if (LP<=0)
        {
            audioSource.PlayOneShot(die);
            agent.destination = transform.position;
            DeadAnime();
            Invoke("Dead", 5.2f);
            Invoke("EnemyDie", 5);
            //Button.SendMessage("Win");
            
        }
    }

    public void Dead()
    {

        Destroy(gameObject);
    }

    public void HurtAnime()
    {
        anim.SetTrigger("T_isHurt");
    }

    public void DeadAnime()
    {
        anim.SetTrigger("T_isDead");
    }

    public void CancelImmortal()
    {
        
        Immortal = false;
    }

    public void EnemyDie()
    {
        enemyCheck.SendMessage("enemyDie");
    }

    //private void OnTriggerFire(Collider other)
    //{
    //    if (other.gameObject.name == "Fire")
    //    {
    //        Debug.Log("fire");
    //        agent.speed = speed * 1.5f;
    //        if (Vector3.Distance(wayPoint, transform.position) <= agent.stoppingDistance)
    //        {
    //            isRun = false;
    //            GetNewWayPoint();
    //        }
    //        else
    //        {
    //            isRun = true;
    //        }
    //    }
    //}

    void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newUp = quat * Vector3.up;
        newUp.z = 0;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = 1.5f;
    }

    void GetNewWayPoint()
    {
        float randomX = Random.Range(-messRange, messRange);
        float randomZ = Random.Range(-messRange, messRange);

        Vector3 randomPonit = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        wayPoint = randomPonit;
    }

    void resetRandomWalkDic()
    {
        resetRandomWalk = true;
    }

    void resetRandomWalkMode()
    {
        randomWalkMode = false;
        Fire.gameObject.SetActive(false);
        speed = 8f;
    }
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position, sightRadius);
    //}
    void SpawnVFX()
    {
        GameObject vfx;
        if(clawpoint != null)
        {
            vfx = Instantiate(effectToSpawn, clawpoint.transform.position, Quaternion.identity);
        }
        else
        {
            print("no");
        }
    }
}
