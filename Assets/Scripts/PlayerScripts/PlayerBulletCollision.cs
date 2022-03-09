using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーの弾の衝突処理のクラスです
/// </summary>
public class PlayerBulletCollision : MonoBehaviour
{
    [SerializeField]
    private float amountDamageDone;

    [SerializeField]
    private GameObject lowPitchPlayerBulletAttackRangeField;

    private float waitDestroyTime = 0.029999999f;

    /// <summary>
    /// エネミーの弾の衝突後外に出た時の処理処理
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(lowPitchPlayerBulletAttackRangeField != null)
            {
                lowPitchPlayerBulletAttackRangeField.SetActive(true);
            }
            StartCoroutine("WaitDestroy");
            other.gameObject.GetComponent<EnemyStatus>().DecreaseEnemyHitPoint(amountDamageDone);
        }
    }

    /// <summary>
    /// 弾の破壊するまでの待機時間
    /// </summary>
    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(waitDestroyTime);

        Destroy(this.gameObject);
    }
}
