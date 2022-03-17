using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomShotBullet : MonoBehaviour
{
    [SerializeField]
    RandomShotEnemyBullet randomShotEnemyBullet;

    void Start()
    {
        randomShotEnemyBullet.CallRandomShot();
    }
}
