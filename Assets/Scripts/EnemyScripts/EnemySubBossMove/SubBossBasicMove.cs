using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サブボスの基本の動き
/// </summary>
public class SubBossBasicMove : MonoBehaviour
{
    [SerializeField]
    private float goalx;

    [SerializeField]
    private float stopTime;    
    
    [SerializeField]
    private float moveSpeedx;

    [SerializeField]
    private GameObject subBoss;

    [SerializeField]
    private Rigidbody2D rb2D;

    private float stopCount = 0;
    private float maxGoaly;
    private float minGoaly;


    void Start()
    {
        
    }

    /// <summary>
    /// サブボスを動かすための関数
    /// </summary>
    public void CallMoveSubBoss()
    {
        StartCoroutine("MoveSubBoss");
    }

    /// <summary>
    /// サブボスの動きを止める関数
    /// </summary>
    public void StopSubBoss()
    {
        stopCount++;
    }

    /// <summary>
    /// サブボスを動かすコルーチン
    /// </summary>
    private IEnumerator MoveSubBoss()
    {
        while (true)
        {
            if(stopCount == 1)
            {
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                this.transform.position = new Vector3(0, 3, 0);
                yield break;
            }
            this.rb2D.velocity = new Vector3(moveSpeedx, 0, 0);
                if (goalx <= this.transform.position.x)
                {
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            
            yield return null;
        } 
    }
}
