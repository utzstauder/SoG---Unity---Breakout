using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour {

    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreLabel;
    }

    //private void Update()
    //{
    //    textComponent.text = "Score " + GameManager.Instance.Score;
    //}


    private void UpdateScoreLabel(int newScore)
    {
        textComponent.text = "Score " + newScore;
    }
}
