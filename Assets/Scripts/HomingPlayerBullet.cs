using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingPlayerBullet : MonoBehaviour
{
    private Vector3 enemyDirection;

    private GameObject enemyObject;

    Rigidbody2D rigid2D;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        StartCoroutine("EnemyShotHoming");
    }


    IEnumerator EnemyShot()
    {
        while (true)
        {
            this.rigid2D.velocity = transform.up * 5;

            if (enemyObject == null)
            {
                enemyObject = GameObject.FindGameObjectWithTag("Enemy");
            }

            if (enemyObject != null)
            {
                enemyDirection = (enemyObject.transform.position - this.transform.position);
                this.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);
            }
            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator EnemyShotHoming()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("EnemyShot");
    }
}
