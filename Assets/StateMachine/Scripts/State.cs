﻿using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public ActionScript[] actions;
    public Transition[] transistions;
    public Color sceneGizmoColor = Color.gray;

    public void UpdateState(StateManager stateManager)
    {
        DoActions(stateManager);
        CheckTransitions(stateManager);
    }

    private void DoActions(StateManager stateManager)
    {
        
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(stateManager);
        }

    }

    private void CheckTransitions(StateManager stateManager)
    {
        for (int i = 0; i < transistions.Length; i++)
        {
            bool decisionsSucceeded = transistions[i].decision.Decide(stateManager);

            if(decisionsSucceeded)
            {
                stateManager.TransitionToState(transistions[i].trueState);
            }
            else
            {
                stateManager.TransitionToState(transistions[i].falseState);
            }
        } 
    }
}
