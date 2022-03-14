using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ボスの最初の動きのスクリプト
/// </summary>
public class BossFirstMovement : MonoBehaviour
{
    [SerializeField]
    List<GameObject> bossMovePositions;

    [SerializeField]
    private Transform bossFirstTrans;

    private int randomMoveStartNumber;

    private int randomMoveEndNumber;

    private int enemyMoveCount;

    [SerializeField]
    private float moveIntervalTime;

    [SerializeField]
    private float intervalTime;

    [SerializeField]
    private float moveStopTime;

    [SerializeField]
    private float bossMoveSpeed;

    [SerializeField]
    private Rigidbody2D rigidBody;

    private Vector3 enemyDirection;

    [System.NonSerialized]
    public bool isFirstMove;

    [SerializeField]
    BossFirstMoveBulletInstance bossFirstMoveBulletInstance;

    private void Start()
    {
        isFirstMove = true;
        enemyMoveCount = 0;
        StartCoroutine("DirectionDesignation");
    }

    /// <summary>
    /// 方向を指定するスクリプト
    /// TODO:条件式を書いて敵のライフがなくなったとき次の動きに移行するようにする
    /// </summary>
    IEnumerator DirectionDesignation()
    {
        bossFirstMoveBulletInstance.CallInstanceBossFirstBullet();
        while (isFirstMove)
        {
            if(enemyMoveCount == 10)
            {
                rigidBody.velocity = transform.up * 0;
                this.gameObject.transform.position = bossFirstTrans.position;
                this.gameObject.transform.rotation = bossFirstTrans.rotation;

                yield return new WaitForSeconds(moveStopTime);
            }

            yield return new WaitForSeconds(intervalTime);

            Random.InitState(System.DateTime.Now.Millisecond);
            randomMoveStartNumber = Random.Range(0, 12);
            this.gameObject.transform.position = bossMovePositions[randomMoveStartNumber].transform.position;

            rigidBody.velocity = transform.up * 0;

            switch (randomMoveStartNumber / 4)
            {
                case 0:
                    randomMoveEndNumber = Random.Range(8, 12);
                    break;
                case 1:
                    randomMoveEndNumber = Random.Range(12, 16);
                    break;
                case 2:
                    randomMoveEndNumber = Random.Range(0, 4);
                    break;
            }
            enemyDirection = (bossMovePositions[randomMoveStartNumber].transform.position - bossMovePositions[randomMoveEndNumber].transform.position);
            this.gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);

            rigidBody.velocity = transform.up * bossMoveSpeed * -1;

            enemyMoveCount++;
        }

        rigidBody.velocity = transform.up * 0;
        this.gameObject.transform.position = bossFirstTrans.position;
        this.gameObject.transform.rotation = bossFirstTrans.rotation;
    }
}
