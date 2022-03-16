using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeforeButtleMove : MonoBehaviour
{
    [SerializeField]
    BossFirstMovement bossFirstMovement;
    [SerializeField]
    private GameObject firstPosition;

    private float moveDistans;

    private float currentTime;


    public void CallMoveBossButtleBefore()
    {
        currentTime = 0;
        moveDistans = (this.gameObject.transform.position.y - firstPosition.transform.position.y) / 100;
        StartCoroutine(MoveBossButtleBefore());
    }

    IEnumerator MoveBossButtleBefore()
    {
        while(currentTime < 1)
        {
            this.gameObject.transform.position -= new Vector3(0, moveDistans, 0);
            currentTime += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
