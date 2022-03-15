using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e�𐶐�����X�N���v�g
/// </summary>
public class ShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyBulletCount;
    [SerializeField] private float enemyBulletGenerationWatingTime;

    private int stopShotEnemyBulletCount = 0;

    void Start()
    {
        
    }

    /// <summary>
    /// �R���[�`�����Ăяo���֐�
    /// </summary>
    public void CallShot()
    {
        StartCoroutine("Shot");
    }

    /// <summary>
    /// ���˂���e���~�߂�֐�
    /// </summary>
    public void StopNormalEnemyBulletShot()
    {
        stopShotEnemyBulletCount = 1;
    }

    /// <summary>
    /// �G�̒e�𐶐�����R���[�`��
    /// </summary>
    private IEnumerator Shot()
    {
        while (true)
        {
            if(stopShotEnemyBulletCount == 1)
            {
                yield break;
            }
            GenerateBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// �G�̒e�𐶐�����֐�
    /// </summary>
    void GenerateBullet()
    {
        for(float j = 0; j < 360; j += 360/enemyBulletCount)
        {
            Instantiate(enemyBullet,this.transform.position, Quaternion.Euler(0, 0, j));
        }
        
    }
}
