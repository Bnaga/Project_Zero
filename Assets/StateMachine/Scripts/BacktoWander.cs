using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Wander")]
public class BacktoWander : Decision {

	public override bool Decide(StateManager stateManager)
	{
		return WanderDecide(stateManager);
	}

	bool WanderDecide(StateManager stateManager)
	{
		if (Vector3.Distance(stateManager.player.transform.position, stateManager.transform.position) >= 6f)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
