using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾が自機狙いをするクラス
/// </summary>
public class EnemyBulletAimPlayer : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerDirection;

    [SerializeField] Rigidbody2D rb2D;

    [SerializeField] private float homingPlayerBulletSpeed;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerDirection = (playerObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
        this.rb2D.velocity = transform.up * homingPlayerBulletSpeed;
    }
}
