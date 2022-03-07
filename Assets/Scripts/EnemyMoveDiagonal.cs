using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の斜め方向のみの移動をさせるクラス
/// </summary>
public class EnemyMoveDiagonal : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool isRight;

    [SerializeField]
    private bool isUp;

    float moveSpeed2;

    void Start()
    {
        moveSpeed2 = moveSpeed;
        if (!isRight)
        {
            moveSpeed *= -1;
        }

        if (!isUp)
        {
            moveSpeed2 *= -1;
        }
    }
    

    void FixedUpdate()
    {
        Vector3 position = new Vector3(moveSpeed, moveSpeed2, 0);
        transform.Translate(position);
    }
}