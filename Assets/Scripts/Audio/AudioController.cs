using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // audioSource.Stop();
            PlayAudio();
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            mixer.SetFloat("MasterPitch", 1.5f);
        }
    }

    public void PlayAudio()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        if (audioClips.Length > 0)
        {
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
        }
        else
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        // audioSource.pitch = 1f;
    }


}
