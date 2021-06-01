using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public GameObject player;
    public float dist;
    NavMeshAgent nav;
    public float radius = 5;
    public GameUI gameUI;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist > radius)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
        if (dist < radius)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Walk");
        }
        if(dist < 1.5f)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Atack");
            StartCoroutine(wait());          
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);

        if (dist < 1.5f)
        {
            gameUI.OnGameOver();
        }
    }
}
