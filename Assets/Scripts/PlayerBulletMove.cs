using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの発射する弾の動きの管理クラス
/// </summary>
public class PlayerBulletMove : MonoBehaviour
{
    /// <summary>
    /// 普通の弾を生成、発射するメソッド
    /// </summary>
    public void CreatNormalPlayerBullet(GameObject normalPlayerBullet, Transform playerTransform, float normalBulletSpeed)
    {
        var playerShot = Instantiate(normalPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * normalBulletSpeed;
    }

    /// <summary>
    /// ピッチが高い時の弾を生成、発射するメソッド
    /// </summary>
    public void CreatHighPitchPlayerBullet(GameObject highPitchPlayerBullet, Transform playerTransform, float highPitchPlayerBulletSpeed)
    {
        var playerShot = Instantiate(highPitchPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * highPitchPlayerBulletSpeed;
    }

    /// <summary>
    /// ピッチが高い時の弾を生成、発射するメソッド
    /// </summary>
    public void CreatLowPitchPlayerBullet(GameObject lowPitchPlayerBullet, Transform playerTransform, float lowPitchPlayerBulletSpeed)
    {
        var playerShot = Instantiate(lowPitchPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * lowPitchPlayerBulletSpeed;
    }
}
