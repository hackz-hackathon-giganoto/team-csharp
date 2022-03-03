using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ピッチの高さを取得するクラス
/// </summary>
public class GetterPitchNumber : MonoBehaviour
{
    private int maxIndex = 0;
    private int freq;// 周波数
    private int pitchNumber;
    private float maxValue = 0.0f;

    [SerializeField]
    private AudioSource aud;

    [SerializeField]
    Text text;

    void Start()
    {
        // マイク名、ループするかどうか、AudioClipの秒数、サンプリングレート を指定する
        aud.clip = Microphone.Start(null, true, 10, 44100);
        aud.Play();
    }
    void FixedUpdate()
    {
        GetPitchNumber();
    }

    /// <summary>
    /// ピッチの高さを数字として取得する
    /// </summary>
    private void GetPitchNumber()
    {
        float[] spectrum = new float[8192];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        maxIndex = 0;
        maxValue = 0.0f;
        for (int i = 0; i < spectrum.Length; i++)
        {
            var val = spectrum[i];
            if (val > maxValue)
            {
                maxValue = val;
                maxIndex = i;
            }
        }
        freq = maxIndex * AudioSettings.outputSampleRate / 2 / spectrum.Length;
        pitchNumber = calculateNoteNumberFromFrequency(freq);
        text.text = pitchNumber.ToString();
    }

    /// <summary>
    /// MIDI Tuning Standard数字を変換する
    /// See https://en.wikipedia.org/wiki/MIDI_tuning_standard
    /// </summary>
    private int calculateNoteNumberFromFrequency(float freq)
    {
        return Mathf.FloorToInt(69 + 12 * Mathf.Log(freq / 440, 2));
    }
}
