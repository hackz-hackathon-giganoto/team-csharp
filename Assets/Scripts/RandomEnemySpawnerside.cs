using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawnerside : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    [SerializeField] private float wait;
    [SerializeField] private float appear;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator GenEnemy()
    {
        for(int i = 0; i < appear; i++)
        {
            Instantiate(enemy, new Vector3(x, y * Random.value, z), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
        yield return StartCoroutine("GenEnemy");
    }
}
