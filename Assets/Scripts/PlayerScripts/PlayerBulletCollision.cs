using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーの弾の衝突時処理のクラスです
/// </summary>
public class PlayerBulletCollision : MonoBehaviour
{
    [SerializeField]
    private float amountDamageDone;
    /// <summary>
    /// エネミーの弾の衝突時処理
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<EnemyStatus>().DecreaseEnemyHitPoint(amountDamageDone);
        }
    }
}
