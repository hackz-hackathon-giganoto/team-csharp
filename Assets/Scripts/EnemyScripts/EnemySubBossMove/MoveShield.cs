using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サブボスの登場時サブボスを守るシールドを移動させるスクリプト
/// </summary>
public class MoveShield : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float goalY;

    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private GameObject shield;

    void Start()
    {
        this.rb2D.velocity = new Vector3(0, -moveSpeed, 0);
        StartCoroutine("StopShield");
    }

    /// <summary>
    /// シールドをボスと一緒に移動させる関数
    /// </summary>
    public void StartShield()
    {
        this.rb2D.velocity = new Vector3(0, -moveSpeed, 0);
        StartCoroutine("StopMoveShield");
    }

    private IEnumerator StopShield()
    {
        while (true)
        {
            if(this.transform.position.y <= goalY)
            {
                this.rb2D.velocity = new Vector3(0, 0, 0);
                Destroy(shield);
                yield break;
            }
            yield return null;
        }
       
    }
}
