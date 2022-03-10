using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの破壊処理
/// </summary>
public class PlayerDestroy : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの破壊メソッド
    /// </summary>
    public void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }
}
