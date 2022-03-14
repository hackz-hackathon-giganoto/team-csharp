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

    private GameObject[] enemyBullets;

    [SerializeField]
    private Transform bossFirstTrans;

    private int randomMoveStartNumber;

    private int randomMoveEndNumber;

    private int bossMoveCount;

    [SerializeField]
    private int bossMoveMaxCount;

    [SerializeField]
    private float intervalTime;

    [SerializeField]
    private float moveStopTime;

    [SerializeField]
    private float nextBattleWaitTime;

    [SerializeField]
    private float bossMoveSpeed;

    [SerializeField]
    private float addUpPower;

    [SerializeField]
    private Rigidbody2D rigidBody;

    private Vector3 enemyDirection;

    [System.NonSerialized]
    public bool isFirstMove;

    [SerializeField]
    BossFirstMoveBulletInstance bossFirstMoveBulletInstance;

    [SerializeField]
    EnemyBulletRotationLoopShot enemyBulletRotationLoopShot;

    private void Start()
    {
        CallDirectionDesignation();
    }

    private void CallDirectionDesignation()
    {
        isFirstMove = true;
        bossMoveCount = 0;
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
            if(bossMoveCount == bossMoveMaxCount)
            {
                rigidBody.velocity = transform.up * 0;
                this.gameObject.transform.position = bossFirstTrans.position;
                this.gameObject.transform.rotation = bossFirstTrans.rotation;

                enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");



                foreach(GameObject enemyBullet in enemyBullets)
                {
                    Rigidbody2D enemyBulletRigidbody = enemyBullet.GetComponent<Rigidbody2D>();
                    enemyBulletRigidbody.velocity = transform.up * addUpPower;
                    enemyBulletRigidbody.gravityScale = 0.3f;
                }

                yield return new WaitForSeconds(moveStopTime);

                bossMoveCount = 0;
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

            bossMoveCount++;
        }

        rigidBody.velocity = transform.up * 0;
        this.gameObject.transform.position = bossFirstTrans.position;
        this.gameObject.transform.rotation = bossFirstTrans.rotation;

        enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

        foreach (GameObject enemyBullet in enemyBullets)
        {
            Destroy(enemyBullet);
        }

        yield return new WaitForSeconds(nextBattleWaitTime);

        enemyBulletRotationLoopShot.CallRotationLoopShotBullet();
    }
}
