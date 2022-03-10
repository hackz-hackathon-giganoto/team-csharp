using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのリスポーン関係の処理
/// </summary>
public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    Transform firstTranseform;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private float waitRespawnTime;

    /// <summary>
    /// リスポーンメソッド
    /// </summary>
    public void RespawnPlayer()
    {
        StartCoroutine("WaitRespawnPlayer");
    }

    /// <summary>
    /// リスポーンまでの待ち時間
    /// </summary>
    IEnumerator WaitRespawnPlayer()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(waitRespawnTime);
        this.gameObject.transform.position = firstTranseform.position;
        spriteRenderer.enabled = true;
    }
}
