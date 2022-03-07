using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの発射する弾の動きの管理クラス
/// </summary>
public class PlayerBulletMove : MonoBehaviour
{
    [SerializeField]
    private float normalBulletSpeed;
    [SerializeField]
    private float highPitchPlayerBulletSpeed;
    [SerializeField]
    private float lowPitchPlayerBulletSpeed;

    [SerializeField]
    private GameObject normalPlayerBullet;
    [SerializeField]
    private GameObject highPitchPlayerBullet;
    [SerializeField]
    private GameObject lowPitchPlayerBullet;

    [SerializeField]
    int bulletCount;

    /// <summary>
    /// 普通の弾を生成、発射するメソッド
    /// </summary>
    public void CreatNormalPlayerBullet()
    {
        Transform playerTransform = this.transform;
        var playerShot = Instantiate(normalPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * normalBulletSpeed;
    }

    /// <summary>
    /// ピッチが高い時の弾を生成、発射するメソッド
    /// TODO:より良い実装がないか探す
    /// </summary>
    public void CreatHighPitchPlayerBullet()
    {
        Transform playerTransform = this.transform;
        CreateMultipleBullet(highPitchPlayerBullet, highPitchPlayerBulletSpeed);
    }

    /// <summary>
    /// ピッチがい時の弾を生成、発射するメソッド
    /// </summary>
    public void CreatLowPitchPlayerBullet()
    {
        Transform playerTransform = this.transform;
        var playerShot = Instantiate(lowPitchPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * lowPitchPlayerBulletSpeed;
    }

    public void CreateMultipleBullet(GameObject multiplePlayerBullet,float bulletSpeed)
    {
        Transform playerTransform = this.transform;
        Vector3 playerForward = playerTransform.up;

        GameObject[] playerShot = new GameObject[bulletCount];

        playerForward.x -= 1;

        float aliquotCount = (bulletCount - 1) / 2f;//弾の飛ぶ方向の分割数

        for (int i = 0; i < bulletCount; i++)
        {
            playerShot[i] = Instantiate(multiplePlayerBullet, playerTransform.position, Quaternion.identity);
            playerShot[i].GetComponent<Rigidbody2D>().velocity = playerForward * bulletSpeed;

            playerForward.x += 1 / aliquotCount;
        }
    }
}
