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

    private int randomMoveStartNumber;

    private int randomMoveEndNumber;

    [SerializeField]
    private float moveIntervalTime;

    [SerializeField]
    private float bossMoveSpeed;

    [SerializeField]
    private Rigidbody2D rigidBody;

    private Vector3 enemyDirection;

    private void Start()
    {
        StartCoroutine("DirectionDesignation");
    }

    /// <summary>
    /// 方向を指定するスクリプト
    /// TODO:力を加えるスクリプトもまとめて書いてあるが、あとで変える
    /// TODO:条件式を書いて敵のライフがなくなったとき次の動きに移行するようにする
    /// </summary>
    IEnumerator DirectionDesignation()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        randomMoveStartNumber = Random.Range(0, 12);

        switch (randomMoveStartNumber/4)
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
        this.gameObject.transform.position = bossMovePositions[randomMoveStartNumber].transform.position;
        enemyDirection = (bossMovePositions[randomMoveStartNumber].transform.position - bossMovePositions[randomMoveEndNumber].transform.position);
        this.gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, enemyDirection);
        yield return new WaitForSeconds(moveIntervalTime);
        rigidBody.velocity = transform.up * bossMoveSpeed * -1;
    }
}
