using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayStage2Manager : MonoBehaviour
{
    [SerializeField]
    GoalPositionManager goalPositionManager;

    [SerializeField]
    GameObject[] enemySpawnHorizons;

    [SerializeField]
    GameObject[] enemySpawnDiagonals;

    GameObject[] enemyBullets;


    void Start()
    {
        StartCoroutine(ManageEnemyMove());
    }

    IEnumerator ManageEnemyMove()
    {
        goalPositionManager.ChengeMainGoalPosition();
        yield return new WaitForSeconds(25f);
        foreach(GameObject enemySpawnHorizon in enemySpawnHorizons)
        {
            enemySpawnHorizon.SetActive(true);

            yield return new WaitForSeconds(3f);
        }
        yield return new WaitForSeconds(17f);

        enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach(GameObject enemyBullet in enemyBullets)
        {
            Destroy(enemyBullet);
        }

        foreach(GameObject enemySpawnDiagonal in enemySpawnDiagonals)
        {
            enemySpawnDiagonal.SetActive(true);
        }
    }
}
