using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    
    public void Initialise ()
    {
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        //check activeState != null
        if (activeState != null)
        {
            activeState.Exit();
        }
        //change to a new state
        activeState = newState;

        //fail-safe null check to make new state wasn't null
        if (activeState != null)
        {
            //setup new state
            activeState.stateMachine = this;
            activeState.npc = GetComponent<NPCAi>();
            activeState.Enter();
        }
    }
}
