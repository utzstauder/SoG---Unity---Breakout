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

    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += UpdateScoreLabel;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScoreLabel;
    }

    private void UpdateScoreLabel(int newScore)
    {
        textComponent.text = "Score " + newScore;
    }
}
