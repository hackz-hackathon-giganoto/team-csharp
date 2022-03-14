using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// “G‚Ì’e‚ğ¶¬‚·‚éƒXƒNƒŠƒvƒg
/// </summary>
public class ShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyBulletCount;
    [SerializeField] private float enemyBulletGenerationWatingTime;
    [SerializeField] private float circleCount;

    void Start()
    {
        StartCoroutine("Shot");
    }

    /// <summary>
    /// “G‚Ì’e‚ğ¶¬‚·‚éƒRƒ‹[ƒ`ƒ“
    /// </summary>
    private IEnumerator Shot()
    {
        while (true)
        {
            GenerateBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// “G‚Ì’e‚ğ¶¬‚·‚éŠÖ”
    /// </summary>
    void GenerateBullet()
    {
        for(float i = 1; i <= circleCount; i++)
        {
            for(float j = 0; j < 360; j += 360/enemyBulletCount)
            {
                Instantiate(enemyBullet,this.transform.position, Quaternion.Euler(0, 0, j));
            }
        }
        
    }
}
