using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    //public GameObject player;
   // public GameObject gameLoseUI;
    public FirstPersonAIO player_mov;
    public GameUI gameUI;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        gameUI.OnGameOver();
    }
}
