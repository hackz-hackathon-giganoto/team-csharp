using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランダムな上方向に向かって弾を発射するクラス
/// </summary>
public class RandomThrowUpShotEnemyBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyGravityBullet;

    [SerializeField]
    private float enemyBulletGenerationSeconds;

    [SerializeField]
    private int enemyGravityBulletCount;

    private float minAngle = 45f;

    private float maxAngle = 135f;

    private bool stopRandomThrowUpEnemyShot;


    /// <summary>
    /// 外からRandomThrowUpEnemyBulletShotを停止するメソッド
    /// </summary>
    public void StopRandomThrowUpEnemyBulletShot()
    {
        stopRandomThrowUpEnemyShot = true;
    }

    /// <summary>
    /// 外からShotRandomGravityBulletを呼び出すメソッド
    /// </summary>
    public void CallShotRandomGravityBullet()
    {
        stopRandomThrowUpEnemyShot = false;
        StartCoroutine(ShotRandomGravityBullet());
    }

    /// <summary>
    /// GravityBulletを間隔をあけて生成するメソッド
    /// </summary>
    private IEnumerator ShotRandomGravityBullet()
    {
        while (true)
        {   
            if(stopRandomThrowUpEnemyShot)
            {
                yield break;
            }
            GenerateRandomGravityBullet();
            yield return new WaitForSeconds(enemyBulletGenerationSeconds);
        }
    }

    /// <summary>
    /// ランダムな上方向に弾を生成するスクリプト
    /// </summary>
    void GenerateRandomGravityBullet()
    {
        float EulerZ;
        
        for (int i = 0; i < enemyGravityBulletCount; i++)
        { 
            EulerZ = Random.Range(minAngle, maxAngle);

            Instantiate(enemyGravityBullet, new Vector3(this.transform.position.x,this.transform.position.y,1), Quaternion.Euler(0, 0, EulerZ)); 
        }
    }
     
}

      
