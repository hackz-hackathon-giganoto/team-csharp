using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 中ボスの左右の移動をするクラス
/// </summary>
public class SubBossBasicMove : MonoBehaviour
{
    [SerializeField]
    private float maxPositionX;

    [SerializeField]
    private float minPositionX;

    [SerializeField]
    private float moveSpeedX;

    [SerializeField]
    private Rigidbody2D rb2D;

    private bool isArrived;

    /// <summary>  
    /// 左から右に移動して右端に来たら左へ移動し始めるメソッドを外から呼び出す
    /// </summary>
    public void CallMoveSubBoss()
    {
        StartCoroutine(MoveSubBoss());
    }

    /// <summary>
    /// 外から中ボスの動きを止めるメソッド
    /// </summary>
    public void StopSubBoss()
    {
        isArrived = true;
    }

    /// <summary>
    /// 左から右に移動して右端に来たら左へ移動し始めるメソッド
    /// </summary>
    private IEnumerator MoveSubBoss()
    {
        while (true)
        {
            if(isArrived)
            {
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                this.transform.position = new Vector3(0, 3, 0);
                yield break;
            }

            if (minPositionX >= this.transform.position.x)
            {
                this.rb2D.velocity = new Vector3(moveSpeedX, 0, 0);
            }
            
            if (maxPositionX <= this.transform.position.x)
            {
                this.rb2D.velocity = new Vector3(moveSpeedX * -1, 0, 0);
            }
            
            yield return null;
        } 
    }
}
