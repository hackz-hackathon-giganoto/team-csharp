using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾が初めに止まってまた動き出すようにするスクリプト
/// </summary>
public class StopFirstEnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float waitTime;    
    [SerializeField] private float minusWaitTime;    
    private float positionX;
    private float positionY;

    [SerializeField] private GameObject enemyObject;
    GameObject[] SubBossBulletCount;

    EnemyBulletRotationShot enemyBulletRotationShotScript;

    void Start()
    {
        enemyBulletRotationShotScript = enemyObject.GetComponent<EnemyBulletRotationShot>();
        waitTime += enemyBulletRotationShotScript.totalTime;
        SubBossBulletCount = GameObject.FindGameObjectsWithTag("SubBossBullet");
        waitTime -= minusWaitTime * SubBossBulletCount.Length;
        Quaternion quaternion = this.transform.rotation;
        float rotationZ = quaternion.eulerAngles.z;
        rotationZ = rotationZ / 180 * Mathf.PI;
        positionX = Mathf.Cos(rotationZ) * bulletSpeed;
        positionY = Mathf.Sin(rotationZ) * bulletSpeed;
        StartCoroutine("MoveBullet");
    }

    /// <summary>
    /// 弾を動かすコルーチン
    /// </summary>
    private IEnumerator MoveBullet()
    {
        this.transform.position += new Vector3(positionX * 200, positionY * 200, 0);
        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            this.transform.position += new Vector3(positionX, positionY, 0);
            yield return null;
        }
    }
}
