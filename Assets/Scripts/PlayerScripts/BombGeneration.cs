using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボム生成のクラス
/// </summary>
public class BombGeneration : MonoBehaviour
{
    [SerializeField]
    GetterPitch getterPitch;
    [SerializeField]
    PlayerStatus playerStatus;
    [SerializeField]
    PlayerShot playerShot;

    [SerializeField]
    BombTimeText bombTimeText;

    [SerializeField]
    private float waitTime;

    [SerializeField]
    private float timeRequired;

    [NonSerialized]
    public float timeCount;

    private void Start()
    {
        StartCoroutine("GenerationBomb");
    }

    /// <summary>
    /// ボムを生成するメソッド
    /// ボス生成に必要な時間を指定すると声を出してない時にだんだん引かれていく
    /// waitTimeは確実に指定しないとゲームが止まる
    /// </summary>
    IEnumerator GenerationBomb()
    {
        timeCount = timeRequired;
        while (timeCount > 0)
        {
            Debug.Log(timeCount);
            if(getterPitch.pitchHighest < playerShot.lowestVolume)
            {
                timeCount -= waitTime;
            }
            yield return new WaitForSeconds(waitTime);
            bombTimeText.SetBombText(timeCount);
        }
        playerStatus.IncreasePlayerBombCount();
        StartCoroutine("GenerationBomb");
    }
}
