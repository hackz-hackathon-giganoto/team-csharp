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

    [SerializeField]
    private EnemyDestroy enemyDestroy;


    /// <summary>
    /// ヒットポイントを減らすメソッド
    /// 引数を設定するとその引数分減らす
    /// </summary>
    public void DecreaseEnemyHitPoint(float point = 1f)
    {
        enemyHitPoint -= point;

        if (enemyHitPoint <= 0)
        {
            enemyDestroy.DestroyEnemy();
        }
    }
}
