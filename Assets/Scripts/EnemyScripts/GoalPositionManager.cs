using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPositionManager : MonoBehaviour
{
    GameObject[] goalPositionObjects;

    [SerializeField]
    private int goalPositionObjectsNumber;

    private int indexNumber;

    void Start()
    {
        indexNumber = 0;
        goalPositionObjects = GameObject.FindGameObjectsWithTag("GoalPosition");

        foreach(GameObject goalPositionObject in goalPositionObjects)
        {
            goalPositionObject.SetActive(false);
        }
        ChengeMainGoalPosition();
    }

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
