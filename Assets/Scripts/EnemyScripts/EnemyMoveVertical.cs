using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の垂直方向のみの移動をさせるクラス
/// </summary>
public class EnemyMoveVertical : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool isUp;

    void Start()
    {
        if (!isUp)
        {
            moveSpeed *= -1;
        }
    }
    

    void FixedUpdate()
    {
        Vector3 position = new Vector3(0, moveSpeed, 0);
        transform.Translate(position);
    }
}