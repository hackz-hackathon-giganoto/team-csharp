using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  プレイヤーのホーミング弾を管理するクラス
/// </summary>
public class HomingPlayerBullet : MonoBehaviour
{
    private Vector3 enemyDirection;

    private GameObject enemyObject;

    private Rigidbody2D rigid2D;

    private float homingPlayerBulletSpeed = 5f;

    private float startHomingShotWaitingTime = 0.5f;

    private float playerHomingShotInterval = 0.2f; 

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        StartCoroutine("WaitPlayerShotHomingBullet");
    }


    /// <summary>
    /// 常にエネミーの方向を向いて進み続ける（ホーミングする）
    /// </summary>
    IEnumerator ShotPlayerHomingBullet()
    {
        while (true)
        {
            this.rigid2D.velocity = transform.up * homingPlayerBulletSpeed;

            if (enemyObject == null)
            {
                enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            }

            if (enemyObject != null)
            {
                enemyDirection = (enemyObject.transform.position - this.transform.position);
                this.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);
            }
            yield return new WaitForSeconds(playerHomingShotInterval);
        }

    }

    /// <summary>
    /// ホーミングし始めるまでの待機時間
    /// </summary>
    IEnumerator WaitPlayerShotHomingBullet()
    {
        yield return new WaitForSeconds(startHomingShotWaitingTime);
        StartCoroutine("ShotPlayerHomingBullet");
    }
}
