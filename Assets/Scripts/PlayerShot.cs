using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーのショット処理
/// </summary>
public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    private float normalBulletSpeed;
    [SerializeField]
    private float highPitchPlayerBulletSpeed;
    [SerializeField]
    private float lowPitchPlayerBulletSpeed;

    [SerializeField]
    private float shotIntervalTime;
    [SerializeField]
    private float lowestVolume;

    [SerializeField]
    private GameObject normalPlayerBullet;
    [SerializeField]
    private GameObject highPitchPlayerBullet;
    [SerializeField]
    private GameObject lowPitchPlayerBullet;

    [SerializeField]
    private int highPlayerPitch;
    [SerializeField]
    private int lowPlayerPitch;

    [SerializeField]
    GetterPitch getterPitch;

    [SerializeField]
    PlayerBulletMove playerBulletMove;

    [SerializeField]
    Text text;

    void Start()
    {
        StartCoroutine("PlayerShotInterval");
    }

    /// <summary>
    /// プレイヤーの弾を打つ間隔
    /// </summary>
    IEnumerator PlayerShotInterval()
    {
        while (true)
        {
            text.text = "high : " + getterPitch.pitchHighest + " num : " + getterPitch.pitchHighestNumber.ToString();
            yield return new WaitForSeconds(shotIntervalTime);

            if (getterPitch.pitchHighest < lowestVolume)
            {
                continue;
            }

            if (getterPitch.pitchHighestNumber < lowPlayerPitch)
            {
                playerBulletMove.CreatLowPitchPlayerBullet(lowPitchPlayerBullet, this.transform, lowPitchPlayerBulletSpeed);
            }
            else if (getterPitch.pitchHighestNumber > highPlayerPitch)
            {
                playerBulletMove.CreatHighPitchPlayerBullet(highPitchPlayerBullet, this.transform, highPitchPlayerBulletSpeed);
            }
            else
            {
                playerBulletMove.CreatNormalPlayerBullet(normalPlayerBullet, this.transform, normalBulletSpeed);
            }
        }
    }
}