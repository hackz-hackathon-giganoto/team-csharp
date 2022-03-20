using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 正直動かしてみてもよくわかんなかったので放置
/// </summary>
public class StopFirstEnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float waitSeconds; 
    private float positionX;
    private float positionY;

    void Start()
    {
        Quaternion quaternion = this.transform.rotation;
        float rotationZ = quaternion.eulerAngles.z;
        rotationZ = rotationZ / 180 * Mathf.PI;
        positionX = Mathf.Cos(rotationZ);
        positionY = Mathf.Sin(rotationZ);
        StartCoroutine("MoveBullet");
    }

    /// <summary>
    /// 
    /// </summary>
    private IEnumerator MoveBullet()
    {
        this.transform.position += new Vector3(positionX * 2, positionY * 2, 0);
        yield return new WaitForSeconds(waitSeconds);
        while (true)
        {
            this.rb2D.velocity = new Vector3(positionX * bulletSpeed, positionY * bulletSpeed, 0);
            yield return null;
        }
    }
}
