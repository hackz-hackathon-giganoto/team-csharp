using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBossToWave2 : MonoBehaviour
{
    [SerializeField]
    EnemyStatus enemyStatus;

    [SerializeField]
    BossBeforeButtleMove beforeButtleMove;

    void FixedUpdate()
    {
        if (enemyStatus.enemyHitPoint < 1)
        {
            Debug.Log("hoge");
            beforeButtleMove.CallMoveBossButtleBefore();
            return;
        }
    }
}
