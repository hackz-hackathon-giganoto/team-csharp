using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// バレットを消す
/// </summary>
public class BulletDestory : MonoBehaviour
{
    [SerializeField] private float time;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        time *= 60;
    }


    // Update is called once per frame
    void FixedUpdate()

    {
        counter += 1;
        if(counter == time)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (GameObject bullet in objects) 
            {
                Destroy(bullet);
            }
        }
    }
}
