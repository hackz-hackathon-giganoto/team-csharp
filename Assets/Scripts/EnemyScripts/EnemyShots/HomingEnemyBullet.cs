using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の弾がプレイヤーを追尾するようになるスクリプト
/// </summary>
public class HomingEnemyBullet : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerPosition;
    private Vector3 bulletPosition;
    private Vector3 playerDirection;

    private float waitTime = 0;
    [SerializeField] private float homingStopTime;
    [SerializeField] private float homingPlayerBulletSpeed;
    [SerializeField] private float generateHomingBulletWait;

    [SerializeField] Rigidbody2D rb2D;
    

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerPosition = playerObject.transform.position;
        bulletPosition = transform.position;
        StartCoroutine("GenerateHomingBullet");
    }

/// <summary>
/// プレイヤーを追尾する弾を生成するコルーチン
/// </summary>
    private IEnumerator GenerateHomingBullet()
    {
        while (true)
        {
            playerPosition = playerObject.transform.position;
            bulletPosition = this.transform.position;
            playerDirection = (playerObject.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
            this.rb2D.velocity = transform.up * homingPlayerBulletSpeed;
            waitTime += generateHomingBulletWait;
            yield return new WaitForSeconds(generateHomingBulletWait);
            if(waitTime == homingStopTime)
            {
                yield break;
            }
        }
        
    }
}
