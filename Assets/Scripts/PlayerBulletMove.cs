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
    /// TODO:より良い実装がないか探す
    /// </summary>
    public void CreatHighPitchPlayerBullet(GameObject highPitchPlayerBullet, Transform playerTransform, float highPitchPlayerBulletSpeed)
    {
        int bulletCount = 3;
        var playerForward = playerTransform.up;

        GameObject[] playerShot = new GameObject[bulletCount];

        playerForward.x -= 1;

        float aliquotCount = (bulletCount - 1) / 2f;//弾の飛ぶ方向の分割数

        for (int i = 0; i < bulletCount; ++i)
        {
            playerShot[i] = Instantiate(highPitchPlayerBullet, playerTransform.position, Quaternion.identity);
            playerShot[i].GetComponent<Rigidbody2D>().velocity = playerForward * highPitchPlayerBulletSpeed;

            playerForward.x += 1 / aliquotCount;
        }
    }

    /// <summary>
    /// ピッチがい時の弾を生成、発射するメソッド
    /// </summary>
    public void CreatLowPitchPlayerBullet(GameObject lowPitchPlayerBullet, Transform playerTransform, float lowPitchPlayerBulletSpeed)
    {
        var playerShot = Instantiate(lowPitchPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * lowPitchPlayerBulletSpeed;
    }
}
