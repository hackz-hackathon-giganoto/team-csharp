using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゴールポストの管理クラス
/// </summary>
public class GoalPositionManager : MonoBehaviour
{
    GameObject[] goalPositionObjects;

    [SerializeField]
    private int goalPositionObjectsNumber;

    private int indexNumber;

    [SerializeField]
    RandomEnemySpawnerLength randomEnemySpawnerlengthBefore;

    [SerializeField]
    RandomEnemySpawnerLength randomEnemySpawnerlengthAfter;
    void Awake()
    {
        indexNumber = 0;
        goalPositionObjects = GameObject.FindGameObjectsWithTag("GoalPosition");

        foreach (GameObject goalPositionObject in goalPositionObjects)
        {
            goalPositionObject.SetActive(false);
        }
    }

    /// <summary>
    /// ゴールポストの切り替えメソッド
    /// </summary>
    public void ChengeMainGoalPosition()
    {
        if (indexNumber == goalPositionObjectsNumber)
        {
            return;
        }
        if(indexNumber == 0)
        {
            randomEnemySpawnerlengthBefore.enabled = true;
        }
        if (indexNumber == 1)
        {
            randomEnemySpawnerlengthAfter.enabled = true;
            Destroy(goalPositionObjects[indexNumber - 1]);
        }
        goalPositionObjects[indexNumber].SetActive(true);
        indexNumber++;
    }
}
