using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 中ボスの出現時の動きのクラス
/// </summary>
public class SubBossAdventMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float goalPositionY;
    [SerializeField]
    private float stopSeconds;

    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private SubBossFirstMove subBossFirstMoveScript;

    void Start()
    {
        this.rb2D.velocity = new Vector3(0, moveSpeed * -1, 0);
        StartCoroutine(StopSubBoss());
    }

    /// <summary>
    /// 中ボスが攻撃を始める地点に来た時、一時的に止まって攻撃をし始めるメソッド
    /// </summary>
    private IEnumerator StopSubBoss()
    {
        while (true)
        {
            if(this.transform.position.y <= goalPositionY)
            {
                this.rb2D.velocity = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(stopSeconds);
                subBossFirstMoveScript.CallSubBossFirstMove();
                yield break;
            }
            yield return null;
        }
        
    }
}
