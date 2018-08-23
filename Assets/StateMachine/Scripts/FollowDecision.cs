using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Follow")]
public class FollowDecision : Decision {
    
    public override bool Decide(StateManager stateManager)
    {
        return FollowDecide(stateManager);
    }

    bool FollowDecide(StateManager stateManager)
    {
        //Debug.Log(Vector3.Distance(stateManager.player.transform.position, stateManager.transform.position));
        if (Vector3.Distance(stateManager.player.transform.position, stateManager.transform.position) <= 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
