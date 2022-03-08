using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーの弾の衝突時処理のクラスです
/// </summary>
public class EnemyBulletCollision : MonoBehaviour
{
    /// <summary>
    /// エネミーの弾の衝突時処理
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<PlayerStatus>().DecreasePlayerHitPoint();
        }
    }
}
