using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour {

    Slider slider;
    [SerializeField, Range(0.01f, 10f)] float duration = 5f;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void OnEnable () {
        StartCoroutine(FillSlider(duration));
	}

    IEnumerator FillSlider(float duration)
    {
        slider.value = 0;
        float progress = 0;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            progress = t / duration;
            slider.value = progress;
            yield return new WaitForEndOfFrame();
        }

        slider.value = 1f;
    }
}
