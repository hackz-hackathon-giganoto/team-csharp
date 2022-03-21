using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定の位置に敵を出現させるクラス
/// </summary>
public class EnemySpawner : MonoBehaviour
{  
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private float positionX;
    [SerializeField]
    private float positionY;

    [SerializeField]
    private float enemyGenerationIntervalSeconds;
    [SerializeField]
    private float enemyGenerationCount;

    void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    /// <summary>
    /// 敵を出現させるコルーチン
    /// </summary>
    private IEnumerator GenerateEnemy()
    {
        for (int i = 0; i < enemyGenerationCount; i++)
        {
            Instantiate(enemyObject, new Vector3(positionX, positionY, 0), Quaternion.identity);
            yield return new WaitForSeconds(enemyGenerationIntervalSeconds);
        }
        yield  break;
    }
}
