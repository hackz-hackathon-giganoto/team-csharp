using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveHorizontal : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool isRight;

    void Start()
    {
        if (!isRight)
        {
            moveSpeed *= -1;
        }
    }
    

    void FixedUpdate()
    {
        Vector3 position = new Vector3(moveSpeed, 0, 0);
        transform.Translate(position);
    }
}