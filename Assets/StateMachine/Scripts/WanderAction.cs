using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : ActionScript {
    
    //float timer = 0;
    bool onDestination = true;
    Vector3 mojiDestination;
    float wanderTimer = 0;
    public float limit = 20f;
    public float rad = 10f;
    public float min = 3f;

    
    public override void Act(StateManager stateManager)
    {
        Wander(stateManager);
    }
    
    public Vector3 RandomNavmeshLocation(Vector3 origin, float radius, StateManager stateManager)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        //randomDirection += stateManager.transform.position;
        randomDirection += origin;
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void Wander(StateManager stateManager)
    {
        wanderTimer += Time.deltaTime;
        onDestination = stateManager.onDestination;
        if (wanderTimer >= limit && !onDestination)
        {
            mojiDestination = RandomNavmeshLocation(stateManager.transform.position,rad, stateManager);
            stateManager.navMeshAgent.SetDestination(mojiDestination);
            wanderTimer = 0;
            
        }

        if (onDestination)
        {
            mojiDestination = RandomNavmeshLocation(stateManager.transform.position,rad, stateManager);
            stateManager.navMeshAgent.SetDestination(mojiDestination);
            stateManager.onDestination = false;
            //UnityEngine.Debug.Log(stateManager.navMeshAgent.destination);
        }


        if (Vector3.Distance(stateManager.transform.position, mojiDestination) < min)
        {
            stateManager.onDestination = true;
        }

    }
}
