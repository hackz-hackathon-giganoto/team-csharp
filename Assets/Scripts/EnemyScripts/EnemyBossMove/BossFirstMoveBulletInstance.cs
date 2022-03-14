using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirstMoveBulletInstance : MonoBehaviour
{
    [SerializeField]
    private GameObject bossFirstBullet;

   public void CallInstanceBossFirstBullet()
   {
        StartCoroutine("InstanceBossFirstBullet");
   }

    IEnumerator InstanceBossFirstBullet()
    {
        while (true)
        {
            Instantiate(bossFirstBullet, this.gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
