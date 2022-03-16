using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBossChange : MonoBehaviour
{
    [SerializeField]
    private GameObject subBossWave;


    void Start()
    {
        StartCoroutine(ChangeSubBoss());
    }

    IEnumerator ChangeSubBoss()
    {
        yield return new WaitForSeconds(45f);
        subBossWave.SetActive(true);
    }
}
