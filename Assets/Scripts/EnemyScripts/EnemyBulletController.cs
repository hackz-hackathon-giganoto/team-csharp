using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を生成するスクリプト
/// </summary>
public class EnemyBulletController : MonoBehaviour
{
    private float positionX;
    private float positionY;
    [SerializeField] private float enemyBulletSpeed;

    void Start()
    {
        Quaternion quaternion = this.transform.rotation;
        float rotationZ = quaternion.eulerAngles.z;
        rotationZ = rotationZ / 180 * Mathf.PI;
        positionX = Mathf.Cos(rotationZ) * enemyBulletSpeed;
        positionY = Mathf.Sin(rotationZ) * enemyBulletSpeed;
    }

    void FixedUpdate()
    {
        this.transform.position += new Vector3(positionX, positionY, 0);
    }
}
