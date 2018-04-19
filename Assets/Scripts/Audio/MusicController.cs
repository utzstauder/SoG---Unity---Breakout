using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            if (audioSource.isPlaying && audioSource.volume > 0)
            {
                Stop();
            } else
            {
                Play();
            }
        }
	}

    private void Stop()
    {
        // audioSource.Stop();
        StartCoroutine(FadeTo(0, 2f));
    }

    private void Play()
    {
        // audioSource.Play();
        StartCoroutine(FadeTo(1f, 1f));
    }

    private IEnumerator FadeTo(float targetVolume, float duration)
    {
        float currentVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(currentVolume, targetVolume, t / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}
