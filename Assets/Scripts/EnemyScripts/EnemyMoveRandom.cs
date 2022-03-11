using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーをランダムに落下させる
/// </summary>

public class EnemyMoveRandom : MonoBehaviour
{
    [SerializeField]
    private float time;

    float moveSpeedx;
    float moveSpeedy;

    void Start()
    {
        time = time * 60;
        float rnd = Random.Range(-4, 4);
        Vector3 firstPosition = GameObject.Find("Enemy b").transform.position;
        float startx = firstPosition.x;
        float starty = firstPosition.y;

        float movex = startx - rnd;
        float movey = starty + 3;

        moveSpeedx = movex / time;
        moveSpeedy = movey / time;
    }


        void FixedUpdate()
    {
        
        Vector3 position = new Vector3(moveSpeedx * -1, moveSpeedy * -1, 0);
        transform.Translate(position);
              
    }
}
