using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// “G‚Ì’e‚ğã•ûŒü‚Éw’è‚µ‚½ŒÂ””­Ë‚·‚éƒXƒNƒŠƒvƒg
/// </summary>
public class RandomThrowUpShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyGravityBullet;

    [SerializeField] private float enemyBulletGenerationWaitTime;

    [SerializeField] private int enemyGravityBulletCount;

    void Start()
    {
        StartCoroutine("RandomGravityBulletShot");
    }

    /// <summary>
    /// “G‚Ì’e‚ğã•ûŒü‚Éw’è‚µ‚½ŒÂ””­Ë‚·‚é‚½‚ß‚ÌŠÖ”
    /// </summary>
    private IEnumerator RandomGravityBulletShot()
    {
        while (true)
        {
            GenerateRandomGravityBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWaitTime);
        }
    }
    /// <summary>
    /// “G‚Ì’e‚ğã•ûŒü‚Éw’è‚µ‚½ŒÂ””­Ë‚·‚éŠÖ”
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

      
