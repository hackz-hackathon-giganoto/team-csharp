using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimeDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DestroyEnemyInterval");
    }

    IEnumerator DestroyEnemyInterval()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
