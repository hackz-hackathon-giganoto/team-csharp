using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーをランダムに落下させる
/// </summary>
public class EnemyMoveRandom : MonoBehaviour
{
    [SerializeField]
    private float moveDuration;

    float moveSpeedx;
    float moveSpeedy;

    void Start()
    {
        moveDuration *= 60;

        float movex = this.gameObject.transform.position.x - Random.Range(-4, 4);
        float movey = this.gameObject.transform.position.y + 3;

        moveSpeedx = movex / moveDuration;
        moveSpeedy = movey / moveDuration;
    }


    void FixedUpdate()
    {
        Vector3 position = new Vector3(moveSpeedx * -1, moveSpeedy * -1, 0);
        transform.Translate(position); 
    }
}
