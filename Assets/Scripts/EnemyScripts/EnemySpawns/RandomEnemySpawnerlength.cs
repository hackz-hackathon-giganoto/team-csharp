using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?G???c???????_?????????????X?N???v?g
/// </summary>
public class RandomEnemySpawnerlength : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float positionX;
    [SerializeField] private float positionY;
    [SerializeField] private float positionZ;
    [SerializeField] private float enemyGenerationWatingTime;
    [SerializeField] private float enemyAppear;

    [SerializeField]
    GoalPositionManager goalPositionManager;

    void Start()
    {
        StartCoroutine("GenerateEnemy");
    }

    /// <summary>
    /// ?G???c???????_?????????????R???[?`??
    /// </summary>
    private IEnumerator GenerateEnemy()
    {
        for(int i = 0; i < enemyAppear; i++)
        {
            Instantiate(enemy, new Vector3(-2.5f + positionX * Random.value, positionY, positionZ), Quaternion.identity);
            yield return new WaitForSeconds(enemyGenerationWatingTime);
        }
        if(goalPositionManager != null)
        {
            goalPositionManager.ChengeMainGoalPosition();
        }
        Destroy(this.gameObject);
    }
}
