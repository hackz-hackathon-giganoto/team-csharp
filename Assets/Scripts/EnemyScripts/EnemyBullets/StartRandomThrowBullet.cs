using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRandomThrowBullet : MonoBehaviour
{
    [SerializeField]
    RandomThrowUpShotEnemyBullet randomThrowUpShotEnemyBullet;

    void Start()
    {
        randomThrowUpShotEnemyBullet.CallShotRandomGravityBullet();
    }
}
