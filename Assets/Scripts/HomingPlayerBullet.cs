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

    Rigidbody2D rigid2D;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        StartCoroutine("WaitEnemyShotHoming");
    }


    /// <summary>
    /// 常にエネミーの方向を向いて進み続ける（ホーミングする）
    /// </summary>
    IEnumerator ShotEnemyHoming()
    {
        while (true)
        {
            this.rigid2D.velocity = transform.up * 5;

            if (enemyObject == null)
            {
                enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            }

            if (enemyObject != null)
            {
                enemyDirection = (enemyObject.transform.position - this.transform.position);
                this.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);
            }
            yield return new WaitForSeconds(0.2f);
        }

    }

    /// <summary>
    /// ホーミングし始めるまでの待機時間
    /// </summary>
    IEnumerator WaitEnemyShotHoming()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("ShotEnemyHoming  ");
    }
}
