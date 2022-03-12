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

    void Start()
    {
        StartCoroutine("Shot");
    }

    /// <summary>
    /// �G�̒e�𐶐�����R���[�`��
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
    /// �G�̒e�𐶐�����֐�
    /// </summary>
    void GenerateBullet()
    {
        for(float i = 0; i < 360; i += 360/enemyBulletCount)
        {
            Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, i));
        }
    }
}
