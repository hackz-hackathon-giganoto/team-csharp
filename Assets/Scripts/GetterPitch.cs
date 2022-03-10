using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ピッチの高さを取得するクラス
/// </summary>
public class GetterPitch : MonoBehaviour
{
    private readonly int SampleNum = (2 << 9); // サンプリング数は2のN乗(N=5-12)
    
    [SerializeField, Range(0f, 1000f)] float m_gain = 200f; // 倍率

    [SerializeField]
    AudioSource m_source;

    [SerializeField]
    LineRenderer m_lineRenderer;

    Vector3 m_sttPos;
    Vector3 m_endPos;

    [NonSerialized]
    public float pitchHighest;
    [NonSerialized]
    public int pitchHighestNumber;

    private string deviceName;

    public string DeviceName { set { deviceName = value; } }

    float[] currentValues;

    void Start()
    {
        m_sttPos = m_lineRenderer.GetPosition(0);
        m_endPos = m_lineRenderer.GetPosition(m_lineRenderer.positionCount - 1);
        currentValues = new float[SampleNum];
        if ((m_source != null) && (Microphone.devices.Length > 0)) // オーディオソースとマイクがある
        {
            if (m_source.clip == null) // クリップがなければマイクにする
            {
                deviceName = Microphone.devices[0]; // 複数見つかってもとりあえず0番目のマイクを使用
                int minFreq, maxFreq;
                Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq); // 最大最小サンプリング数を得る
                int ms = minFreq / SampleNum; // サンプリング時間を適切に取る
                m_source.loop = true; // ループにする
                m_source.clip = Microphone.Start(deviceName, true, ms, minFreq); // clipをマイクに設定
                while (!(Microphone.GetPosition(deviceName) > 0)) { } // きちんと値をとるために待つ
                Microphone.GetPosition(null);
                m_source.Play();
            }
        }
    }

    void FixedUpdate()
    {
        GetCurrentPitch();
    }

    /// <summary>
    /// 現在のピッチを取得する
    /// TODO:適切な命名が思い浮かばなかったのでコメントアウトは変更する
    /// </summary>
    void GetCurrentPitch()
    {
        m_source.GetSpectrumData(currentValues, 0, FFTWindow.Hamming);
        int levelCount = currentValues.Length / 8; // 高周波数帯は取らない
        Vector3[] positions = new Vector3[levelCount];
        for (int i = 0; i < levelCount; i++)
        {
            positions[i] = m_sttPos + (m_endPos - m_sttPos) * (float)i / (float)(levelCount - 1);
            positions[i].y += currentValues[i] * m_gain;
        }
        pitchHighest = Utils.GetHighest(positions);
        pitchHighestNumber = Utils.GetHighestNumber(positions);
    }
}
