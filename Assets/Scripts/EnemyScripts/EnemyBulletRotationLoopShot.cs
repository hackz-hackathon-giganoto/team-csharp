using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ?G???e???~?????????????X?N???v?g
/// </summary>
public class EnemyBulletRotationLoopShot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float enemyBulletGenerationWaitingTime;
    [SerializeField] private float enemyBulletRotationInterval;
    [SerializeField] private float enemyBulletGenerationWaitingTimeAdd;
    [SerializeField] private float enemyBulletGenerationOnceRotationInterval;

    bool addEnemyAngle;

    void Start()
    {
        StartCoroutine("ShotBullet");
        addEnemyAngle = false;
    }

    /// <summary>
    /// ?G???e?????]???????????????????R???[?`??
    /// </summary>
    private IEnumerator ShotBullet()
    {
        while(true)
        {
            if (enemyBulletRotationInterval < 10) addEnemyAngle = true;
            if (enemyBulletRotationInterval > 20) addEnemyAngle = false;
            if (!addEnemyAngle) enemyBulletRotationInterval -= 1f;
            if (addEnemyAngle) enemyBulletRotationInterval += 1f;

            for (float j = 0; j < 360; j += enemyBulletRotationInterval, enemyBulletGenerationWaitingTime += enemyBulletGenerationWaitingTimeAdd)
            {
                Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, j));
                yield return new WaitForSeconds(enemyBulletGenerationWaitingTime);
            }
            yield return new WaitForSeconds(enemyBulletGenerationOnceRotationInterval);
        }
    }
}