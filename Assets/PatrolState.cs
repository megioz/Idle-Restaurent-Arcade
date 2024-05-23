using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;
    
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
    }
    public void PatrolCycle()
    {
        //Implement Logic
        if(npc.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            npc.anim.SetBool("Go", false);

            if (waitTimer > 0 && npc.isActive == false)
            {

                if (waypointIndex < npc.path.waypoints.Count - 1)
                {
                    waypointIndex++;
                }

                else
                    waypointIndex = 0;

                if (waypointIndex == npc.path.waypoints.Count - 1)
                {

                    npc.anim.SetBool("Go", false);
                    npc.interactImage.SetActive(true);
                    npc.isActive = true;



                }
                if (npc.isActive == false)
                {
                    npc.Agent.SetDestination(npc.path.waypoints[waypointIndex].position);
                    npc.transform.rotation = Quaternion.RotateTowards(npc.transform.rotation, npc.path.waypoints[waypointIndex].rotation, 360);
                    npc.anim.SetBool("Go", true);
                }
            }
        }
    }
}
