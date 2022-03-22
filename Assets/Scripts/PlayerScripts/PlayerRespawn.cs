using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのリスポーン関係の処理
/// </summary>
public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    private Transform firstTranseform;

    [SerializeField]
    private float waitRespawnSeconds;

    /// <summary>
    /// リスポーンメソッド
    /// </summary>
    public void CallRespawnPlayer()
    {
        StartCoroutine(WaitRespawnPlayer());
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

        yield return new WaitForSeconds(waitRespawnSeconds);
        this.gameObject.transform.position = firstTranseform.position;

        foreach (GameObject playerObject in playerObjects)
        {
            playerObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
