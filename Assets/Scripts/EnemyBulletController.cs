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
        float _Rotation_z = quaternion.eulerAngles.z;
        _Rotation_z = _Rotation_z / 180 * Mathf.PI;
        positionX = Mathf.Cos(_Rotation_z) * enemyBulletSpeed;
        positionY = Mathf.Sin(_Rotation_z) * enemyBulletSpeed;
    }

    void FixedUpdate()
    {
        this.transform.position += new Vector3(positionX, positionY, 0);
    }
}
