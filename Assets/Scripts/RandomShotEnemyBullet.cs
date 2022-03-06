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

    void Start()
    {
        StartCoroutine("RandomShot");
    }

    /// <summary>
    /// �G�̒e�������_���Ő�������R���[�`��
    /// </summary>
    private IEnumerator RandomShot()
    {
        while (true)
        {
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
