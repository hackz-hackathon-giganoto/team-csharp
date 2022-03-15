using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスの最初の動きで弾を生成するクラス
/// </summary>
public class BossFirstMoveBulletInstance : MonoBehaviour
{
    public float waitInstanceTime;

    [SerializeField]
    private GameObject bossFirstBullet;

    [SerializeField]
    BossFirstMovement bossFirstMovement;

    /// <summary>
    /// 外からコルーチンを実行するメソッド
    /// </summary>
    public void CallInstanceBossFirstBullet()
    {
        StartCoroutine("InstanceBossFirstBullet");
    }

    /// <summary>
    /// 弾を生成するメソッド
    /// </summary>
    IEnumerator InstanceBossFirstBullet()
    {
        while (bossFirstMovement.isFirstMove)
        {
            Instantiate(bossFirstBullet, this.gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitInstanceTime);
        }
    }
}
