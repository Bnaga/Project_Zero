using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Follow")]
public class FollowAction : ActionScript {
	public override void Act(StateManager stateManager)
	{
		FollowPlayer(stateManager);
	}

	private void FollowPlayer(StateManager stateManager)
	{
		stateManager.navMeshAgent.SetDestination(stateManager.player.transform.position);
		if (Vector3.Distance(stateManager.transform.position, stateManager.player.transform.position) < 2)
		{
			SceneManager.LoadScene(4);
		}
	}
}
