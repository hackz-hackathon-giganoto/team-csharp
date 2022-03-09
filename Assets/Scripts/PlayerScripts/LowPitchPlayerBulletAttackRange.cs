using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ピッチが低い時の弾の攻撃範囲
/// </summary>
public class LowPitchPlayerBulletAttackRange : MonoBehaviour
{
    [SerializeField]
    private float amountDamageDone;

  
    /// <summary>
    /// ピッチが低い時の弾の攻撃範囲内にいる敵にダメージを与える
    /// </summary>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {   
            other.gameObject.GetComponent<EnemyStatus>().DecreaseEnemyHitPoint(amountDamageDone);
        }
    }
}
