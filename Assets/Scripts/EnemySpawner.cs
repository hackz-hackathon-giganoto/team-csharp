using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵を定位置に生成するスクリプト
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
    /// 敵を定位置に生成するコルーチン
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
