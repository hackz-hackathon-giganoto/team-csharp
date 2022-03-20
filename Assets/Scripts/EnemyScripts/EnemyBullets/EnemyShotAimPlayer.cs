using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機狙いの弾の管理クラス
/// </summary>
public class EnemyShotAimPlayer : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float intervalSeconds;

    [SerializeField]
    private GameObject enemyBullet;

    private GameObject playerObject;

    private Vector3 enemyDirection;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); ;
        StartCoroutine("EnemyShotInterval");
    }

    void FixedUpdate()
    {
        enemyDirection = (playerObject.transform.position - this.gameObject.transform.position);
        this.gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);
    }

    /// <summary>
    /// 敵の弾を打つ間隔
    /// </summary>
    IEnumerator EnemyShotInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalSeconds);
            var enemyShot = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            enemyShot.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        }
    }
}
