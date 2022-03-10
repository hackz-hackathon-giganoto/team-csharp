using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �G�̒e���v���C���[��ǔ�����悤�ɂȂ�X�N���v�g
/// </summary>
public class HomingEnemyBullet : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerPosition;
    private Vector3 bulletPosition;
    private float bulletPositionX;
    private float bulletPositionY;
    private float playerPositionX;
    private float playerPositionY;
    private float x;
    private float y;
    [SerializeField] private float homingPlayerBulletSpeed;
    [SerializeField] private float generateHomingBulletWait;
    [SerializeField] Rigidbody2D rb2D;
    private Vector3 playerDirection;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerPosition = playerObject.transform.position;
        bulletPosition = transform.position;
        StartCoroutine("GenerateHomingBullet");
    }

/// <summary>
/// �v���C���[��ǔ�����e�𐶐�����R���[�`��
/// </summary>
    private IEnumerator GenerateHomingBullet()
    {
        while (true)
        {
            playerPosition = playerObject.transform.position;
            bulletPosition = this.transform.position;
            playerDirection = (playerObject.transform.position - this.transform.position);
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, playerDirection);
            this.rb2D.velocity = transform.up * homingPlayerBulletSpeed;
            yield return new WaitForSeconds(generateHomingBulletWait);
        }
        
    }
}
