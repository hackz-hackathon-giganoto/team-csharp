using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の斜め方向のみの移動をさせるクラス
/// </summary>
public class EnemyMoveDiagonal : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedX;

    [SerializeField]
    private bool isRight;

    [SerializeField]
    private bool isUp;

    float moveSpeedY;

    void Start()
    {
        moveSpeedY = moveSpeedX;
        if (!isRight)
        {
            moveSpeedX *= -1;
        }

        if (!isUp)
        {
            moveSpeedY *= -1;
        }
    }
    

    void FixedUpdate()
    {
        Vector3 position = new Vector3(moveSpeedX, moveSpeedY, 0);
        transform.Translate(position);
    }
}