using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G���ʒu�ɐ�������X�N���v�g
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float positionX;
    [SerializeField] private float positionY;
    [SerializeField] private float positionZ;
    [SerializeField] private float enemyGenerationWatingTime;
    [SerializeField] private float enemyAppear;

    void Start()
    {
        StartCoroutine("GenerateEnemy");
    }

    /// <summary>
    /// �G���ʒu�ɐ�������R���[�`��
    /// </summary>
    private IEnumerator GenerateEnemy()
    {
        for (int i = 0; i < enemyAppear; i++)
        {
            Instantiate(enemy, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
            yield return new WaitForSeconds(enemyGenerationWatingTime);
        }
        yield  break;
    }
}
