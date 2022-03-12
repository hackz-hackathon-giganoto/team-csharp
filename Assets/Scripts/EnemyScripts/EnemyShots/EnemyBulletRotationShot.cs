using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ????????????????
/// </summary>
public class EnemyBulletRotationShot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float enemyBulletGenerationWaitingTime;
    [SerializeField] private float enemyBulletRotationCount;
    [SerializeField] private float enemyBulletRotationInterval;
    [SerializeField] private float enemyBulletGenerationWaitingTimeAdd;
    [SerializeField] private float enemyBulletGenerationOnceRotationInterval;

    void Start()
    {
        StartCoroutine("ShotBullet");
    }

    /// <summary>
    /// ????????????????????
    /// </summary>
    private IEnumerator ShotBullet()
    {
        for(float i = 0; i < enemyBulletRotationCount; i++)
        {
            for (float j = 0; j < 360; j += enemyBulletRotationInterval, enemyBulletGenerationWaitingTime += enemyBulletGenerationWaitingTimeAdd)
            {
                Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, j));
                yield return new WaitForSeconds(enemyBulletGenerationWaitingTime);
            }
            yield return new WaitForSeconds(enemyBulletGenerationOnceRotationInterval);
        }
    }
}
