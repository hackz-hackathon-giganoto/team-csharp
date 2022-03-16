using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private Transform firstPosition;

    private GameObject goalPosition;

    [SerializeField]
    private float time;

    [SerializeField]
    private float stopTime;

    float moveSpeedx;
    float moveSpeedy;
    float counter = 0;


    void Start()
    {
        //time = time * 60;
        //stopTime = stopTime * 60;
        goalPosition = GameObject.FindGameObjectWithTag("GoalPosition");

        float startx = firstPosition.position.x;
        float starty = firstPosition.position.y;

        float movex = startx - goalPosition.transform.position.x * Random.value * 2;
        float movey = starty - goalPosition.transform.position.y;

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
        else if(counter > time * 2 + stopTime)
        {
            Destroy(this.gameObject);
        }
    }
    
}
