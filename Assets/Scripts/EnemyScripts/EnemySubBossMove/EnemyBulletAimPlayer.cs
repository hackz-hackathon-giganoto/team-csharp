using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAimPlayer : MonoBehaviour
{

    private GameObject playerObject;
    private Vector3 playerPosition;
    private Vector3 bulletPosition;
    private Vector3 playerDirection;

    [SerializeField] Rigidbody2D rb2D;

    [SerializeField] private float homingPlayerBulletSpeed;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerPosition = playerObject.transform.position;
        bulletPosition = this.transform.position;
        playerDirection = (playerObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
        this.rb2D.velocity = transform.up * homingPlayerBulletSpeed;
    }
}
