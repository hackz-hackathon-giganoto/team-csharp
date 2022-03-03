using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float x;
    public float y;
    public float z;
    public float appear;
    public float wait;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenEnemy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private IEnumerator GenEnemy()
    {
        for (int i = 0; i < appear; i++)
        {
            Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
        yield  break;
    }
}
