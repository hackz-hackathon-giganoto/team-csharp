using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private float goalx;

    [SerializeField]
    private float goaly;

    [SerializeField]
    private float time;

    [SerializeField]
    private float stopTime;

    float moveSpeedx;
    float moveSpeedy;
    float counter = 0;
    

    void Start()
    {
        time = time * 60;
        stopTime = stopTime * 60;
        Vector3 firstPosition = GameObject.Find("Enemy a").transform.position;
        float startx = firstPosition.x;
        float starty = firstPosition.y;

        float movex = startx - goalx;
        float movey = starty - goaly;

        moveSpeedx = movex / time;
        moveSpeedy = movey / time;
    }
    

    void FixedUpdate()
    {
        counter += 1;
        if (counter <= time)
        {
            Vector3 position = new Vector3(moveSpeedx * -1, moveSpeedy * -1, 0);
            transform.Translate(position);
        }        
        else if (time + stopTime <= counter && counter <= time*2 + stopTime )
        {
           Vector3 position = new Vector3(moveSpeedx, moveSpeedy, 0);
            transform.Translate(position); 
        }
    }
    
}
