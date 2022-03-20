using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 落ちる弾の生成（弾を生成するだけの）クラス
/// </summary>
public class FallEnemyBullet : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    [SerializeField]
    private float waitSeconds;

    void Start()
    {
        StartCoroutine(WaitInstans());
    }

    /// <summary>
    /// 弾の一定期間で生成するメソッド
    /// </summary> 
    IEnumerator WaitInstans()
    {
        while (true)
        {
            Instantiate(enemyBullet, this.gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitSeconds);
        }
    }
}