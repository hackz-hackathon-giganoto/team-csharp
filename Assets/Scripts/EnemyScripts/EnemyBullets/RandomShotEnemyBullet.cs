 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾をランダムで生成するクラス
/// </summary>
public class RandomShotEnemyBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyBullet;

    [SerializeField]
    private float enemyBulletGenerationIntervalSeconds;

    [SerializeField]
    private int randomShotCount;

    [SerializeField]
    private Transform enemyTransform;

    private bool stopRandomEnemyShot;

    /// <summary>
    /// 外からコルーチンを呼び出すメソッド
    /// </summary>
    public void CallRandomEnemyShot()
    {
        StartCoroutine(ShotRandomEnemyBullet());
    }

    /// <summary>
    /// ShotRandomEnemyBulletを外側から停止する
    /// </summary>
    public void StopRandomEnemyShot()
    {
        stopRandomEnemyShot = true;
    }

    /// <summary>
    /// ランダムな方向に弾を発射するメソッド
    /// </summary>
    private IEnumerator ShotRandomEnemyBullet()
    {
        while (true)
        {
            for(int i = 0; i < randomShotCount; i++)
            {
                if(stopRandomEnemyShot)
                {
                    yield break;
                }

                Instantiate(
                    enemyBullet,
                    new Vector3(enemyTransform.position.x, enemyTransform.position.y, 1),
                    Quaternion.Euler(0, 0, Random.value * 360)
                );
            }
            yield return new WaitForSeconds(enemyBulletGenerationIntervalSeconds);
        }
    }
}
