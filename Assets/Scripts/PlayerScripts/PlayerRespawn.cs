using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    Transform firstTranseform;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    public void RespawnPlayer()
    {
        StartCoroutine("WaitRespawnPlayer");
    }

    IEnumerator WaitRespawnPlayer()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.transform.position = firstTranseform.position;
        spriteRenderer.enabled = true;
    }
}
