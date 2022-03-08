using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
