using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動き出して、しばらく止まったらまた動き出すクラス
/// </summary>
public class EnemyMovePause : MonoBehaviour
{
    [SerializeField]
    private Transform firstPosition;

    private GameObject goalPosition;

    [SerializeField]
    private float moveFrame;

    [SerializeField]
    private float stopFrame;

    float moveSpeedx;
    float moveSpeedy;
    float frameCounter = 0;


    void Start()
    {
        goalPosition = GameObject.FindGameObjectWithTag("GoalPosition");

        float movex = firstPosition.position.x - goalPosition.transform.position.x * Random.value * 2;
        float movey = firstPosition.position.y - goalPosition.transform.position.y;

        moveSpeedx = movex / moveFrame;
        moveSpeedy = movey / moveFrame;
    }
    

    void FixedUpdate()
    {
        frameCounter += 1;
        if (frameCounter <= moveFrame)
        {
            Vector3 position = new Vector3(moveSpeedx * -1, moveSpeedy * -1, 0);
            transform.Translate(position);
        }        
        else if (moveFrame + stopFrame <= frameCounter && frameCounter <= moveFrame*2 + stopFrame )
        {
           Vector3 position = new Vector3(moveSpeedx, moveSpeedy, 0);
            transform.Translate(position); 
        }
        else if(frameCounter > moveFrame * 2 + stopFrame)
        {
            Destroy(this.gameObject);
        }
    }
    
}
