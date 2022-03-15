using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?G???e???????????w???????????????????X?N???v?g
/// </summary>
public class RandomThrowUpShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyGravityBullet;

    [SerializeField] private float enemyBulletGenerationWaitTime;

    [SerializeField] private int enemyGravityBulletCount;

    private int stopRandomThrowUpEnemyBulletShotCount = 0;

    /// <summary>
    /// ?????????e???~????????
    /// </summary>
    public void StopRandomThrowUpEnemyBulletShot()
    {
        stopRandomThrowUpEnemyBulletShotCount = 1;
    }

    /// <summary>
    /// ?R???[?`?????????o??????
    /// </summary>
    public void CallRandomThrowUpShot()
    {
        StartCoroutine("RandomGravityBulletShot");
    }

    /// <summary>
    /// ?G???e???????????w????????????????????????????
    /// </summary>
    private IEnumerator RandomGravityBulletShot()
    {
        while (true)
        {   
            if(stopRandomThrowUpEnemyBulletShotCount == 1)
            {
                yield break;
            }
            GenerateRandomGravityBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWaitTime);
        }
    }

    /// <summary>
    /// ?G???e???????????w??????????????????????
    /// </summary>
    void GenerateRandomGravityBullet()
    {
        float EulerZ;
        

        for (int i = 0; i < enemyGravityBulletCount; i++)
        { 
            while(true)
            {
                EulerZ = Random.value * 360;
                if(EulerZ <= 135 && EulerZ >= 45)
                {
                    break;
                }
            }
            Instantiate(enemyGravityBullet, this.transform.position, Quaternion.Euler(0, 0, EulerZ)); 
        }
    }
     
}

      
