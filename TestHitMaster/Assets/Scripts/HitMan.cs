using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HitMan : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    
    int waypointIndex = 0;

    private NavMeshAgent agentPlayer;
    Animator animator;
    
    public GameObject other;

    enum State {PlayRun, StartPlay, Attack}
    State state = State.StartPlay;

    public GameObject BulletPoint;
    public GameObject BulletPrefab;


    void Start()
    {
        state = State.StartPlay;
        transform.position = waypoints[waypointIndex].transform.position;
        agentPlayer = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        TapMouse();
        RunPlayer();
        Idle();  
    }

    void TapMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(waypointIndex <=0)
            {
                waypointIndex +=1;
                state = State.PlayRun;
            }
            Shooting();  
        }
    }

    public void Waypoint()
    {
        waypointIndex +=1;
        state = State.PlayRun;   
    }

    void RunPlayer()
    {
        if(state == State.PlayRun)
        {
            animator.Play("Running");
            Move();
        }
    }

    void Move()
    {
        agentPlayer.SetDestination(waypoints[waypointIndex].transform.position);
    }
    void Idle()
    {
        if(transform.position.z == waypoints[waypointIndex].transform.position.z)
        {
            if(waypointIndex >=1)
            {
                state = State.Attack;
            }
            animator.SetTrigger("Idle");
            if(waypointIndex == waypoints.Length - 1)
            {
                SceneManager.LoadScene(0);   
            }
        }
    }
    void Shooting()
    {
        if(state == State.Attack)
        {
            AE_FireBullet();
        }
    }

    public void AE_FireBullet()
    {
        GameObject BulletObj = Instantiate(BulletPrefab, BulletPoint.transform.position, BulletPoint.transform.rotation);
    }


}
