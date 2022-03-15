using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimeDestroy : MonoBehaviour
{
    [SerializeField]
    private float waitTime;
    void Start()
    {
        StartCoroutine("DestroyEnemyInterval");
    }

    IEnumerator DestroyEnemyInterval()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
