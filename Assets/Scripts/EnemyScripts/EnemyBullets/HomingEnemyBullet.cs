using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ?G???e???v???C???[?????????????????????X?N???v?g
/// </summary>
public class HomingEnemyBullet : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerPosition;
    private Vector3 bulletPosition;
    private Vector3 playerDirection;

    private float waitTime = 0;
    [SerializeField] private float homingStopTime;
    [SerializeField] private float homingPlayerBulletSpeed;
    [SerializeField] private float generateHomingBulletWait;

    [SerializeField] Rigidbody2D rb2D;
    

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject == null)
        {
            Destroy(this.gameObject);
        }
        playerPosition = playerObject.transform.position;
        bulletPosition = transform.position;
        StartCoroutine("GenerateHomingBullet");
    }

/// <summary>
/// ?v???C???[???????????e???????????R???[?`??
/// </summary>
    private IEnumerator GenerateHomingBullet()
    {
        while (true)
        {
            if (playerObject == null)
            {
                Destroy(this.gameObject);
            }
            playerPosition = playerObject.transform.position;
            bulletPosition = this.transform.position;
            playerDirection = (playerObject.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
            this.rb2D.velocity = transform.up * homingPlayerBulletSpeed;
            waitTime += generateHomingBulletWait;
            yield return new WaitForSeconds(generateHomingBulletWait);
            if(waitTime == homingStopTime)
            {
                yield break;
            }
        }
        
    }
}
