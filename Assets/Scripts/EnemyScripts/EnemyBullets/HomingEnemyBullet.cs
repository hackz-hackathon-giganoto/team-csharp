using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の弾がプレイヤーを追尾するようになるスクリプト
/// </summary>
public class HomingEnemyBullet : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerDirection;

    [SerializeField]
    private float homingStopSeconds;
    [SerializeField]
    private float homingBulletSpeed;
    [SerializeField]
    private float generateHomingBulletWaitSeconds;

    private float waitSeconds;

    [SerializeField]
    private Rigidbody2D rb2D;
    

    void Start()
    {
        waitSeconds = 0;
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject == null)
        {
            Destroy(this.gameObject);
        }
        StartCoroutine("GenerateHomingBullet");
    }

    /// <summary>
    /// プレイヤーを追尾する弾を生成するコルーチン
    /// </summary>
    private IEnumerator GenerateHomingBullet()
    {
        while (true)
        {
            if (playerObject == null)
            {
                Destroy(this.gameObject);
            }
            playerDirection = (playerObject.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
            this.rb2D.velocity = transform.up * homingBulletSpeed;
            waitSeconds += generateHomingBulletWaitSeconds;
            yield return new WaitForSeconds(generateHomingBulletWaitSeconds);
            if(waitSeconds == homingStopSeconds)
            {
                yield break;
            }
        }
        
    }
}
