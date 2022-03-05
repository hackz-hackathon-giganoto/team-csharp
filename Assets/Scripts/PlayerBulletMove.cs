using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    public void CreatPlayerNormalBullet(GameObject normalPlayerBullet, Transform playerTransform, float normalBulletSpeed)
    {
        var playerShot = Instantiate(normalPlayerBullet, playerTransform.position, Quaternion.identity);
        playerShot.GetComponent<Rigidbody2D>().velocity = playerTransform.up * normalBulletSpeed;
    }
}
