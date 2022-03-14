using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// “G‚Ì’e‚ğ‰~ó‚É¶¬‚·‚éƒXƒNƒŠƒvƒg
/// </summary>
public class EnemyBulletRotationShot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float enemyBulletGenerationWaitingTime;
    [SerializeField] private float enemyBulletRotationCount;
    [SerializeField] private float enemyBulletRotationInterval;
    [SerializeField] private float enemyBulletGenerationWaitingTimeAdd;
    [SerializeField] private float enemyBulletGenerationOnceRotationInterval;
    private float keepCount;
    public float totalTime;
    private float totalAddTime;
    private float totalWaitAddTime;
    void Start()
    {
        keepCount = enemyBulletGenerationWaitingTime;
        totalTime = 0;
        for(int i = 0;i < 360 / enemyBulletRotationInterval;i++)
        {
            totalWaitAddTime += keepCount;
            totalAddTime += enemyBulletGenerationWaitingTimeAdd;
        }
        totalTime = enemyBulletRotationCount * (enemyBulletGenerationOnceRotationInterval + ((360 / enemyBulletRotationInterval) * enemyBulletGenerationWaitingTime) + totalAddTime);
        StartCoroutine("ShotBullet");
    }

    /// <summary>
    /// “G‚Ì’e‚ğ‰ñ“]‚·‚é‚æ‚¤‚É¶¬‚·‚éƒRƒ‹[ƒ`ƒ“
    /// </summary>
    private IEnumerator ShotBullet()
    {
        for(float i = 0; i < enemyBulletRotationCount; i++)
        {
            for(float j = 0; j < 360; j += enemyBulletRotationInterval, enemyBulletGenerationWaitingTime += enemyBulletGenerationWaitingTimeAdd)
            {
                Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, j));
                yield return new WaitForSeconds(enemyBulletGenerationWaitingTime);
            }
            yield return new WaitForSeconds(enemyBulletGenerationOnceRotationInterval);
        }
    }
}
