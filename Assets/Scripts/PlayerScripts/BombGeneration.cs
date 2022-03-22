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
    private float playerSilenceSeconds;

    [NonSerialized]
    public float secondsCountDown;

    private float timeRequired;

    private void Start()
    {
        StartCoroutine(GenerationBomb());
    }

    /// <summary>
    /// ボムを生成するメソッド
    /// ボス生成に必要な時間を指定すると声を出してない時にだんだん引かれていく
    /// waitTimeは確実に指定しないとゲームが止まる
    /// </summary>
    IEnumerator GenerationBomb()
    {
        secondsCountDown = timeRequired;
        while (secondsCountDown > 0)
        {
            Debug.Log(secondsCountDown);
            if(getterPitch.pitchHighest < playerShot.lowestVolume)
            {
                secondsCountDown -= playerSilenceSeconds;
            }
            yield return new WaitForSeconds(playerSilenceSeconds);
            bombTimeText.SetBombText(secondsCountDown);
        }
        playerStatus.IncreasePlayerBombCount();
        StartCoroutine(GenerationBomb());
    }
}
