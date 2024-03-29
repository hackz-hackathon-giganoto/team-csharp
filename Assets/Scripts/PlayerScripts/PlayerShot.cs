using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーのショット処理
/// </summary>
public class PlayerShot : MonoBehaviour
{
    public float LowestVolume;

    [SerializeField]
    private float normalShotIntervalTime;
    [SerializeField]
    private float highShotIntervalTime;
    [SerializeField]
    private float lowShotIntervalTime;
    [SerializeField]
    private float homingShotIntervalTime;

    [SerializeField]
    private float homingPlayerBulletFirstSpeed;

    private float currentShotIntervalTime;

    [SerializeField]
    private int highPlayerPitch;
    [SerializeField]
    private int lowPlayerPitch;

    [SerializeField]
    private GameObject homingPlayerBullet;

    [SerializeField]
    private GetterPitch getterPitch;

    [SerializeField]
    private PlayerBulletMove playerBulletMove;

    void Start()
    {
        currentShotIntervalTime = normalShotIntervalTime;

        StartCoroutine(PlayerShotInterval());
        StartCoroutine(PlayerHomingShotInterval());
    }
    /// <summary>
    /// プレイヤーの弾を打つ間隔
    /// </summary>
    IEnumerator PlayerShotInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentShotIntervalTime);

            if (getterPitch.pitchHighest < LowestVolume)
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

    /// <summary>
    /// ホーミング弾を打つ間隔
    /// </summary>
    IEnumerator PlayerHomingShotInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(homingShotIntervalTime);

            if (getterPitch.pitchHighest < LowestVolume)
            {
                continue;
            }

            if (getterPitch.pitchHighestNumber < highPlayerPitch && getterPitch.pitchHighestNumber > lowPlayerPitch)
            {
                playerBulletMove.CreateMultipleBullet(homingPlayerBullet, homingPlayerBulletFirstSpeed);
            }

        }
    }
}