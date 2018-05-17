using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synthesizer : MonoBehaviour {

    #region Classes

    public class Voice
    {
        public int noteNumber;
        public float velocity;

        float frequency;
        float gain;
        float sampleRate;
        double phase;
        double increment;

        private System.Random random = new System.Random();

        private WaveType waveType;

        bool isActive;

        public Voice(WaveType waveType)
        {
            noteNumber = -1;
            velocity = 0;

            isActive = false;

            this.waveType = waveType;
        }

        public void NoteOn(int noteNumber, float velocity)
        {
            this.noteNumber = noteNumber;
            this.velocity = velocity;
            this.frequency = Synthesizer.NoteToFrequency(noteNumber);

            phase = 0;
            sampleRate = AudioSettings.outputSampleRate;

            isActive = true;
        }

        public void NoteOff(int noteNumber)
        {
            if (noteNumber == this.noteNumber)
            {
                isActive = false;
            }
        }

        public void WriteAudioBuffer(ref float[] data, int channels)
        {
            if (!isActive) return;

            increment = frequency * 2 * Mathf.PI / sampleRate;

            // write audio buffer
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
                            data[i + c] = gain * (Mathf.PingPong((float)phase, 1f) * 2f - 1f);
                            break;

                        case WaveType.Sawtooth:
                            data[i + c] = gain * (Mathf.InverseLerp(0, Mathf.PI * 2, (float)phase) * 2 - 1f);
                            break;

                        case WaveType.Noise:
                            data[i + c] = gain * (((float)random.NextDouble() * 2f) - 1f);
                            break;

                        default:
                            break;
                    }
                }

            }
        }
    }

    #endregion

    public enum WaveType
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

    private NoteInput input;

    private float sampleRate;
    private double phase;
    private double increment;
    private float frequency = 440f;

    [SerializeField]
    private WaveType waveType = WaveType.Sine;


    [SerializeField, Range(0, 1f)]
    private float gain = 1f;

    private bool isActive = false;
    private int activeNoteNumber = -1;

    private System.Random random = new System.Random();
    // random.NextDouble();

    #endregion


    #region Unity Messages

    private void Awake()
    {
        sampleRate = (float)AudioSettings.outputSampleRate;

        input = GetComponent<NoteInput>();
    }

    private void OnEnable()
    {
        if (input != null)
        {
            input.OnNoteOn -= Input_OnNoteOn;
            input.OnNoteOn += Input_OnNoteOn;

            input.OnNoteOff -= Input_OnNoteOff;
            input.OnNoteOff += Input_OnNoteOff;
        }
    }


    private void OnDisable()
    {
        if (input != null)
        {
            input.OnNoteOn -= Input_OnNoteOn;

            input.OnNoteOff -= Input_OnNoteOff;
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
                        data[i + c] = gain * (Mathf.PingPong((float)phase, 1f) * 2f - 1f);
                        break;

                    case WaveType.Sawtooth:
                        data[i + c] = gain * (Mathf.InverseLerp(0, Mathf.PI * 2, (float)phase) * 2 - 1f);
                        break;

                    case WaveType.Noise:
                        data[i + c] = gain * (((float)random.NextDouble() * 2f) - 1f) ;
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


    #region Event Handler

    private void Input_OnNoteOn(int noteNumber, float velocity)
    {
        Debug.LogFormat("NoteOn: {0}", noteNumber);
        frequency = NoteToFrequency(noteNumber);
        activeNoteNumber = noteNumber;
        isActive = true;
    }

    private void Input_OnNoteOff(int noteNumber)
    {
        Debug.LogFormat("NoteOff: {0}", noteNumber);
        if (noteNumber == activeNoteNumber)
        {
            isActive = false;
        }
    }

    #endregion

}
