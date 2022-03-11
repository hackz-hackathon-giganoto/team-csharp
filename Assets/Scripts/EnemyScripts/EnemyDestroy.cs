using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーの破壊処理
/// </summary>
public class EnemyDestroy : MonoBehaviour
{

    /// <summary>
    /// エネミーの破壊メソッド
    /// </summary>
    void Start()
    {
        int rnd = Random.Range(0, 2);
    }
    
    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
        
    }
}
