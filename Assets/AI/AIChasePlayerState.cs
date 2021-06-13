using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayerState : AIState
{
    public void Enter(AIAgent agent)
    {
    }

    public void Exit(AIAgent agent)
    {      
    }

    public AIStateId GetId()
    {
        return AIStateId.ChasePlayer;
    }

    public void Update(AIAgent agent)
    {
        //if (!agent.enabled)
        //{
        //    return;
        //}

        ////timer -= Time.deltaTime;
        //if (!agent.navMeshAgent.hasPath)
        //{
        //    agent.navMeshAgent.destination = agent.playerTransform.position;
        //}
        //if (timer < 0.0f)
        //{
            //Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            //direction.y = 0;
            //if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            //{
            //    if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
            //    {
            //        agent.navMeshAgent.destination = agent.playerTransform.position;
            //    }
            //}
            //else
            //{
            //    agent.stateMachine.ChangeState(AIStateId.Atack);
            //}
            agent.config.dist = Vector3.Distance(agent.playerTransform.position, agent.transform.position);
            if (agent.config.dist < agent.config.maxSightDistance)
            {
                agent.navMeshAgent.enabled = true;
                agent.navMeshAgent.SetDestination(agent.playerTransform.position);
                agent.GetComponent<Animator>().SetTrigger("Walk");
            }
            if (agent.config.dist > agent.config.maxSightDistance)
            {
                agent.stateMachine.ChangeState(AIStateId.Idle);
            }
            if (agent.config.dist < 1.5f)
            {

                agent.stateMachine.ChangeState(AIStateId.Atack);
            }
               // timer = agent.config.maxTime;
       // }

    }
}
