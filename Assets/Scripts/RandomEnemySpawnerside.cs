using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵を横にランダムで生成するスクリプト
/// </summary>
public class RandomEnemySpawnerside : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    [SerializeField] private float PositionX;
    [SerializeField] private float PositionY;
    [SerializeField] private float PositionZ;
    [SerializeField] private float enemyGenerationWatingTime;
    [SerializeField] private float enemyAppear;

    void Start()
    {
        StartCoroutine("GenerateEnemy");
    }

    /// <summary>
    /// 敵を横にランダムで生成するコルーチン
    /// </summary>
    private IEnumerator GenerateEnemy()
    {
        for(int i = 0; i < enemyAppear; i++)
        {
            Instantiate(enemy, new Vector3(PositionX, PositionY * Random.value, PositionZ), Quaternion.identity);
            yield return new WaitForSeconds(enemyGenerationWatingTime);
        }
    }
}
