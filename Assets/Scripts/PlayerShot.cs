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
    private float normalShotIntervalTime;
    [SerializeField]
    private float lowestVolume;

    [SerializeField]
    private GameObject normalPlayerBullet;

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

    private void Update()
    {
        text.text = "num:" + getterPitch.pitchHighestNumber.ToString() + " high:" + getterPitch.pitchHighest.ToString();
    }

    /// <summary>
    /// プレイヤーの弾を打つ間隔
    /// </summary>
    IEnumerator PlayerShotInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(normalShotIntervalTime);

            if (getterPitch.pitchHighest < lowestVolume)
            {
                continue;
            }

            if(getterPitch.pitchHighestNumber < highPlayerPitch && getterPitch.pitchHighestNumber > lowPlayerPitch)
            {
                playerBulletMove.CreatPlayerNormalBullet(normalPlayerBullet, this.transform, normalBulletSpeed);
            }
        }
    }
}