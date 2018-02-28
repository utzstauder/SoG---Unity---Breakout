using System.Collections;
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

    public GameState gameState { get; private set; }

    // EXAMPLE!

    private int expPerLevel = 10;

    public int Experience { get; private set; }

    public int Lvl {
        get {
            return Experience / expPerLevel;
        }
    }

    public float LvlProgress {
        get {
            return (Experience % expPerLevel) / (float)expPerLevel;
        }
    }

    // 

    #region Public Properties

    public static GameManager Instance;

    #endregion


    #region Private Properties

    private int score = 0;

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

        exp = 235;
        Debug.Log(lvl);
        Debug.Log(lvlProgress);
    }

    #endregion


    #region Public Functions

    public int GetScore()
    {
        return score;
    }

    #endregion
}
