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
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject playerObject in playerObjects)
        {
            playerObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(waitRespawnTime);
        this.gameObject.transform.position = firstTranseform.position;

        foreach (GameObject playerObject in playerObjects)
        {
            playerObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
