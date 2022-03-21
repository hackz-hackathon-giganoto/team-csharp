using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// X軸をランダムで出現するスクリプト 
/// </summary>
public class RandomEnemySpawnerLength : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private float positionY;
    [SerializeField]
    private float enemyGenerationIntervalSeconds;
    [SerializeField]
    private int enemyGenerationCount;

    private int maxPositionX = 4;

    private int minPositionX = -4;

    [SerializeField]
    private GoalPositionManager goalPositionManager;

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
            Instantiate(enemyObject, new Vector3(Random.Range(minPositionX, maxPositionX), positionY, 0), Quaternion.identity);
            yield return new WaitForSeconds(enemyGenerationIntervalSeconds);
        }
        if(goalPositionManager != null)
        {
            goalPositionManager.ChengeMainGoalPosition();
        }
        Destroy(this.gameObject);
    }
}
