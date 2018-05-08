using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synthesizer : MonoBehaviour {

    enum WaveType
    {
        Sine,
        Square,
        Triangle,
        Sawtooth,
        Noise
    }

    #region Constants

    const int fixedNoteNumber = 69;
    const float fixedFrequency = 440f;

    #endregion


    #region Private Fields

    private float sampleRate;
    private double phase;
    private double increment;

    [SerializeField]
    private WaveType waveType = WaveType.Sine;

    [SerializeField, Range(220f, 880f)]
    private float frequency = 440f;

    [SerializeField, Range(0, 1f)]
    private float gain = 1f;

    private bool isActive = false;

    #endregion


    #region Unity Messages

    private void Awake()
    {
        sampleRate = (float)AudioSettings.outputSampleRate;
    }

    private void Update()
    {
        isActive = false;

        if (Input.GetKey(KeyCode.A))
        {
            frequency = NoteToFrequency(60);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            frequency = NoteToFrequency(62);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            frequency = NoteToFrequency(64);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.F))
        {
            frequency = NoteToFrequency(65);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.G))
        {
            frequency = NoteToFrequency(67);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.H))
        {
            frequency = NoteToFrequency(69);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.J))
        {
            frequency = NoteToFrequency(71);
            isActive = true;
        }

        if (Input.GetKey(KeyCode.K))
        {
            frequency = NoteToFrequency(72);
            isActive = true;
        }
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        //Debug.LogFormat("Buffer size: {0} | Channel count: {1}",
        //    data.Length / channels,
        //    channels);

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = 0;
        }

        if (!isActive) return;

        increment = frequency * 2 * Mathf.PI / sampleRate;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase += increment;

            if (phase > (Mathf.PI * 2))
            {
                phase -= Mathf.PI * 2;
            }

            for (int c = 0; c < channels; c++)
            {
                switch (waveType)
                {
                    case WaveType.Sine:
                        data[i + c] = gain * Mathf.Sin((float)phase);
                        break;

                    case WaveType.Square:
                        if (Mathf.Sin((float)phase) >= 0)
                        {
                            data[i + c] = gain;
                        }
                        else
                        {
                            data[i + c] = -gain;
                        }
                        break;

                    case WaveType.Triangle:

                        break;

                    case WaveType.Sawtooth:

                        break;

                    case WaveType.Noise:

                        break;

                    default:
                        break;
                }
            }

        }

    }

    #endregion


    #region Static Public Functions

    static public float NoteToFrequency(int noteNumber)
    {
        float twelfthRoot = Mathf.Pow(2f, (1f / 12f));
        return fixedFrequency * Mathf.Pow(twelfthRoot, noteNumber - fixedNoteNumber);
    }

    #endregion

}
