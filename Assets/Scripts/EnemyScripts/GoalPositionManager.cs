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
        goalPositionObjects[indexNumber].SetActive(true);
        indexNumber++;
    }
}
