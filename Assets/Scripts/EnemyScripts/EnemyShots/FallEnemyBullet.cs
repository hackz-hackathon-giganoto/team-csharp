using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEnemyBullet : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    [SerializeField]
    private float waitTime;

    void Start()
    {
        StartCoroutine(hoge());
    }

    IEnumerator hoge()
    {
        while (true)
        {
            Instantiate(enemyBullet, this.gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
