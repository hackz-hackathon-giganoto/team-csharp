using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーのショット処理
/// </summary>
public class PlayerShot : MonoBehaviour
{

    private float currentShotIntervalTime;
    [SerializeField]
    private float normalShotIntervalTime;
    [SerializeField]
    private float highShotIntervalTime;
    [SerializeField]
    private float lowShotIntervalTime;
    [SerializeField]
    private float homingShotIntervalTime;

    [SerializeField]
    private float lowestVolume;

    [SerializeField]
    private int highPlayerPitch;
    [SerializeField]
    private int lowPlayerPitch;


    [SerializeField]
    private GameObject homingPlayerBullet;

    [SerializeField]
    GetterPitch getterPitch;

    [SerializeField]
    PlayerBulletMove playerBulletMove;

    [SerializeField]
    Text text;

    void Start()
    {
        currentShotIntervalTime = normalShotIntervalTime;
        StartCoroutine("PlayerShotInterval");
        StartCoroutine("PlayerHomingShotInterval");
    }

    /// <summary>
    /// プレイヤーの弾を打つ間隔
    /// </summary>
    IEnumerator PlayerShotInterval()
    {
        while (true)
        {
            text.text = "high : " + getterPitch.pitchHighest + " num : " + getterPitch.pitchHighestNumber.ToString();
            yield return new WaitForSeconds(currentShotIntervalTime);

            if (getterPitch.pitchHighest < lowestVolume)
            {
                continue;
            }

            if (getterPitch.pitchHighestNumber > highPlayerPitch)
            {
                playerBulletMove.CreatHighPitchPlayerBullet();
                currentShotIntervalTime = highShotIntervalTime;
            }
            else if (getterPitch.pitchHighestNumber < lowPlayerPitch)
            {
                playerBulletMove.CreatLowPitchPlayerBullet();
                currentShotIntervalTime = lowShotIntervalTime;
            }
            else
            {
                playerBulletMove.CreatNormalPlayerBullet();
                currentShotIntervalTime = normalShotIntervalTime;
            }
        }
    }

    IEnumerator PlayerHomingShotInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(homingShotIntervalTime);

            if (getterPitch.pitchHighest < lowestVolume)
            {
                continue;
            }

            if (getterPitch.pitchHighestNumber > highPlayerPitch)
            {
                playerBulletMove.CreateMultipleBullet(homingPlayerBullet, 3);
            }

        }
    }
}