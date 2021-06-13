using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAtackState : AIState
{
    float timer = 1.5f;
    public void Enter(AIAgent agent)
    {
    }

    public void Exit(AIAgent agent)
    {
    }

    public AIStateId GetId()
    {
        return AIStateId.Atack;
    }

    public void Update(AIAgent agent)
    {
        
        agent.config.dist = Vector3.Distance(agent.playerTransform.position, agent.transform.position);
        Vector3 agentDirection = agent.transform.forward;
        Vector3 playerDirection = (agent.playerTransform.position - agent.transform.position);
        playerDirection.Normalize();
        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if (agent.config.dist < 1.5f && dotProduct > 0.0f)  
        {
            agent.navMeshAgent.enabled = false;
            agent.GetComponent<Animator>().SetTrigger("Atack");
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        else
        {
            timer = agent.config.maxTime;
            agent.stateMachine.ChangeState(AIStateId.Idle);            
        }
        if (timer < 0)
        {
            agent.gameUI.OnGameOver();
        }
       
    }
    
}
