using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̒e�������_���Ő�������X�N���v�g
/// </summary>
public class RandomShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyBulletGenerationWatingTime;

    private int stopRandomShotEnemyBulletCount = 0;

    void Start()
    {
        
    }

    /// <summary>
    /// �R���[�`�����Ăяo���֐�
    /// </summary>
    public void CallRandomShot()
    {
        StartCoroutine("RandomShot");
    }

    /// <summary>
    /// ���˂���e���~�߂�֐�
    /// </summary>
    public void StopRandomEnemyBulletShot()
    {
        stopRandomShotEnemyBulletCount = 1;
    }

    /// <summary>
    /// �G�̒e�������_���Ő�������R���[�`��
    /// </summary>
    private IEnumerator RandomShot()
    {
        while (true)
        {
            if(stopRandomShotEnemyBulletCount == 1)
            {
                yield break;
            }
            GenerateRandomBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// �G�̒e�������_���Ő�������֐�
    /// </summary>
    void GenerateRandomBullet()
    {
        Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, Random.value * 360));
    }
}
