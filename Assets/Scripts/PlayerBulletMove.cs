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
    public void CreatPlayerNormalBullet(GameObject normalPlayerBullet, Transform playerTransform, float normalBulletSpeed)
    {
        var playerShot = Instantiate(normalPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * normalBulletSpeed;
    }
}
