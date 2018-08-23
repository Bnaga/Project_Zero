using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class StateManager : MonoBehaviour {

    //public Transform eyes;
    public State currentState;
    public State remainState;

    public int curState = 0;
    public int tempState = 0;
    public int waitSec = 15;
    public float interMax = 10;
    public float coolDownMax = 10;
    public Vector3 offset;

    public bool hide = false;
    public bool inDanger = false;
    public bool onDestination = true;
    public bool hasFood = false;
    public bool isInteracting = false;
    public GameObject player;

    [HideInInspector] public NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Awake ()
    {
        curState = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        onDestination = true;
        //navMeshAgent.destination = Vector3.zero;
        //animator = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void Start()
    {
     hide = false;
     inDanger = false;
     onDestination = true;
     hasFood = false;
     isInteracting = false;
    }

    private void Update()
    {
        currentState.UpdateState(this);
        //StartCoolDown();
        //animator.SetFloat("speed", navMeshAgent.speed);
        //animator.speed = navMeshAgent.speed * 10;
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }

    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }

    #region randomStates

    public void RandomSoldierState()
    {
        tempState = Random.Range(0, 10);
        if (tempState < 9)
        {
            curState = 6; // leader/soldier wander
        }
        if (tempState == 9)
        {
            curState = 3; // go to nearest mojili
        }
    }

    
    #endregion
    
}
