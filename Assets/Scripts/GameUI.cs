﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameLoseUI;
    //public GameObject gameWinUI;
    public FirstPersonAIO player_mov;
    bool gameIsOver;

    void Start()
    {
        //Guard.OnGuardHasSpottedPlayer += ShowGameLose;
        //FindObjectOfType<FirstPersonAIO>().OnReachedEnd += ShowGameWin;
    }

    void Update()
    {
        if (gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    public void OnGameOver()
    {
        gameLoseUI.SetActive(true);
        gameIsOver = true;
        player_mov.enabled = false;
    }
}
