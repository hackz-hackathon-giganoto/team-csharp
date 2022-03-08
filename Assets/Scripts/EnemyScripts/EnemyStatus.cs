using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーのステータス管理クラス
/// </summary>
public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    private float enemyHitPoint;

    private EnemyDestroy enemyDestroy;

    private void Start()
    {
        enemyDestroy = gameObject.GetComponent<EnemyDestroy>();
    }

    private void FixedUpdate()
    {
        if(enemyHitPoint <= 0)
        {
            enemyDestroy.DestroyEnemy();
        }
    }

    /// <summary>
    /// ヒットポイントを減らすメソッド
    /// 引数を設定するとその引数分減らす
    /// </summary>
    public void DecreaseEnemyHitPoint(float point = 1f)
    {
        enemyHitPoint -= point;
    }
}
