using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エネミーの破壊処理
/// </summary>

public class EnemyDestroy : MonoBehaviour
{

    [SerializeField]
    GenerationItem generationItem; 

    /// <summary>
    /// エネミーの破壊メソッド
    /// </summary>
    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
        generationItem.Generation();
    }
}
