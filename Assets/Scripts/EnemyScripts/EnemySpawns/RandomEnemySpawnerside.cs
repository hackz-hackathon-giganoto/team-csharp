using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Y軸をランダムで出現するスクリプト 
/// </summary>
public class RandomEnemySpawnerSide : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private float PositionX;
    [SerializeField]
    private float enemyGenerationIntervalSeconds;

    [SerializeField]
    private int enemyGenerationCount;

    private int maxPositionY = 5;

    private int minPositionY = -5;

    void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    /// <summary>
    /// 敵を出現させるコルーチン
    /// </summary>
    private IEnumerator GenerateEnemy()
    {
        for(int i = 0; i < enemyGenerationCount; i++)
        {
            Instantiate(enemyObject, new Vector3(PositionX, Random.Range(minPositionY, maxPositionY), 0), Quaternion.identity);
            yield return new WaitForSeconds(enemyGenerationIntervalSeconds);
        }
    }
}
