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

    [SerializeField]
    private Rigidbody2D rigid2D;

    [SerializeField]
    private float homingShotStartWaitSeconds;

    [SerializeField]
    private float homingBulletSpeed;

    [SerializeField]
    private float homingShotInterval; 

    void Start()
    {
        StartCoroutine(WaitPlayerShotHomingBullet());
    }


    /// <summary>
    /// 常にエネミーの方向を向いて進み続ける（ホーミングする）
    /// </summary>
    IEnumerator ShotPlayerHomingBullet()
    {
        while (true)
        {
            this.rigid2D.velocity = transform.up * homingBulletSpeed;

            if (enemyObject == null)
            {
                enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            }

            enemyDirection = (enemyObject.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);

            yield return new WaitForSeconds(homingShotInterval);
        }
    }

    /// <summary>
    /// ホーミングし始めるまでの待機時間
    /// </summary>
    IEnumerator WaitPlayerShotHomingBullet()
    {
        yield return new WaitForSeconds(homingShotStartWaitSeconds);
        StartCoroutine(ShotPlayerHomingBullet());
    }
}
