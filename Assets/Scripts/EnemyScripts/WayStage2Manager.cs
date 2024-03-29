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

    [SerializeField]
    private GameObject subBoss;

    private void Start()
    {
        StartCoroutine(ManageEnemyMove());
    }

    IEnumerator ManageEnemyMove()
    {
        goalPositionManager.ChengeMainGoalPosition();
        yield return new WaitForSeconds(28f);
        enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

        foreach (GameObject enemyBullet in enemyBullets)
        {
            Destroy(enemyBullet);
        }

        foreach (GameObject enemySpawnHorizon in enemySpawnHorizons)
        {
            enemySpawnHorizon.SetActive(true);

            yield return new WaitForSeconds(3f);
        }

        yield return new WaitForSeconds(17f);

        enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

        foreach (GameObject enemyBullet in enemyBullets)
        {
            Destroy(enemyBullet);
        }

        foreach (GameObject enemySpawnDiagonal in enemySpawnDiagonals)
        {
            enemySpawnDiagonal.SetActive(true);
        }

        yield return new WaitForSeconds(20f);
        subBoss.SetActive(true);

    }
}
