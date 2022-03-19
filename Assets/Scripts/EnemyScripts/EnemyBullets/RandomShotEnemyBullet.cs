using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?G???e???????_?????????????X?N???v?g
/// </summary>
public class RandomShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyBulletGenerationWatingTime;

    [SerializeField] private int RandomShotCount;

    [SerializeField]
    private Transform enemyTransform;
    private int stopRandomShotEnemyBulletCount = 0;

    /// <summary>
    /// ?R???[?`?????????o??????
    /// </summary>
    public void CallRandomShot()
    {
        StartCoroutine("RandomShot");
    }

    /// <summary>
    /// ?????????e???~????????
    /// </summary>
    public void StopRandomEnemyBulletShot()
    {
        stopRandomShotEnemyBulletCount = 1;
    }

    /// <summary>
    /// ?G???e???????_?????????????R???[?`??
    /// </summary>
    private IEnumerator RandomShot()
    {
        while (true)
        {
            for(int i = 0; i < RandomShotCount; i++)
            {
                if(stopRandomShotEnemyBulletCount == 1)
            {
                yield break;
            }
            GenerateRandomBullet();
            }
            
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// ?G???e???????_????????????????
    /// </summary>
    void GenerateRandomBullet()
    {
        Instantiate(enemyBullet, new Vector3(enemyTransform.position.x,enemyTransform.position.y,1), Quaternion.Euler(0, 0, Random.value * 360));
    }
}