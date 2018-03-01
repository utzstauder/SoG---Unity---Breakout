﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        idle    = 0,
        loading = 1,
        playing = 2,
        paused  = 3
    }



    #region Public Properties

    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    public int Score { get; private set; }

    #endregion


    #region Private Fields

    #endregion


    #region Unity Messages

    private void Awake()
    {
        if (Instance != null)
        {
            // There is already another instance of GameManager
            Destroy(gameObject);
        }
        else
        {
            // This is the GameManager instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Score += 5;
        }
    }

    #endregion


    #region Public Functions

    #endregion
}
