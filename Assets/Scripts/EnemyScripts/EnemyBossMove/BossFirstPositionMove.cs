using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスが最初の位置に移動するためのクラス
/// </summary>
public class BossFirstPositionMove : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPosition;

    [SerializeField]
    private float moveTime;

    private float moveDistans;

    private float currentTime;

    /// <summary>
    /// 外から呼び出すメソッド
    /// </summary>
    public void CallMoveBossButtleBefore()
    {
        currentTime = 0;
        moveDistans = (this.gameObject.transform.position.y - firstPosition.transform.position.y) / 100;
        StartCoroutine(MoveBossButtleBefore());
    }

    /// <summary>
    /// 秒数の分だけ実際に動かすメソッド
    /// </summary>
    IEnumerator MoveBossButtleBefore()
    {
        while(currentTime < moveTime)
        {
            this.gameObject.transform.position -= new Vector3(0, moveDistans, 0);
            currentTime += moveTime/100f;
            yield return new WaitForSeconds(moveTime / 100f);
        }
    }
}
