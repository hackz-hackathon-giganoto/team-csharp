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

    bool hoge;

    void Start()
    {
        StartCoroutine("ShotBullet");
        hoge = false;
    }

    /// <summary>
    /// ?G???e?????]???????????????????R???[?`??
    /// </summary>
    private IEnumerator ShotBullet()
    {
        while(true)
        {
            if (enemyBulletRotationInterval < 10) hoge = true;
            if (enemyBulletRotationInterval > 20) hoge = false;
            if (!hoge) enemyBulletRotationInterval -= 1f;
            if (hoge) enemyBulletRotationInterval += 1f;

            for (float j = 0; j < 360; j += enemyBulletRotationInterval, enemyBulletGenerationWaitingTime += enemyBulletGenerationWaitingTimeAdd)
            {
                Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, j));
                yield return new WaitForSeconds(enemyBulletGenerationWaitingTime);
            }
            yield return new WaitForSeconds(enemyBulletGenerationOnceRotationInterval);
        }
    }
}