using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e��������Ɏw�肵�������˂���X�N���v�g
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
    /// �G�̒e��������Ɏw�肵�������˂��邽�߂̊֐�
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
    /// �G�̒e��������Ɏw�肵�������˂���֐�
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

      
