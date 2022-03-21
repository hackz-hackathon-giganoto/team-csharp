using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?????????????????
/// </summary>
public class SubBossFirstMove : MonoBehaviour
{
    [SerializeField]
    private GameObject aimPlayerEnemyBullet;

    [SerializeField]
    private float intervalSeconds;

    private float changePositionX;

    private bool finishFirstMove;

    private float maxPositionX = 4f;

    private float maxPositionY = 4f;

    /// <summary>
    /// ??????????????????????????????????????????????
    /// </summary>
    public void CallSubBossFirstMove()
    {
        finishFirstMove = false;
        StartCoroutine(FirstSubBossMove());
    }

    /// <summary>
    /// FirstSubBossMove???????????
    /// </summary>
    public void StopSubBossFirstMove()
    {
        finishFirstMove = true;
    }

    /// <summary>
    /// ??????????????????????????????????????
    /// </summary>
    private IEnumerator FirstSubBossMove()
    {
        while(!finishFirstMove)
        {  
            changePositionX = (Random.value < 0.5f) ? 1 : -1;

            this.transform.position = new Vector3(Random.Range(0 , maxPositionX)* changePositionX, Random.Range(0 , maxPositionY), 0);

            Instantiate(aimPlayerEnemyBullet, this.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(intervalSeconds);
        }

        this.transform.position = new Vector3(-4, 3, 0);
    }
}
