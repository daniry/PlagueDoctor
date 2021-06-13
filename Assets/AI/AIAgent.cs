using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AIStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig config;
    public Transform playerTransform;
    public GameUI gameUI;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIAtackState());
        stateMachine.RegisterState(new AIIdleState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        stateMachine.Update();
    }

}
