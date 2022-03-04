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
    GetterPitchNumber getterPitchNumber;


    [SerializeField]
    Text text;

    void Start()
    {
        StartCoroutine("PlayerShotInterval");
    }

    private void Update()
    {
        text.text = getterPitchNumber.pitchHighest.ToString();
    }

    /// <summary>
    /// プレイヤーの弾を打つ間隔
    /// </summary>
    IEnumerator PlayerShotInterval()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(normalShotIntervalTime);
            if (getterPitchNumber.pitchHighest > lowestVolume)
            {
                var playerShot = Instantiate(normalPlayerBullet, transform.position, Quaternion.identity);
                playerShot.GetComponent<Rigidbody2D>().velocity = transform.up * normalBulletSpeed;
            }
        }
    }
}