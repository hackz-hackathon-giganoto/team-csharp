using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �T�u�{�X���o�������Ƃ��ɏ��߂ɂ��铮��
/// </summary>
public class SubBossFirstMove : MonoBehaviour
{
    [SerializeField] private GameObject AimPlayerEnemyBullet;

    [SerializeField] private float moveCount;
    [SerializeField] private float waitTime;
    private float changeXPosition;
    private float changeJudge;
    private float stopSubBossFirstMoveCount = 0;

    void Start()
    {
         
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// �T�u�{�X�̍ŏ��̓������n�߂�֐�
    /// </summary>
    public void CallSubBossFirstMove()
    {
       StartCoroutine("FirstMove");
    }

    /// <summary>
    /// �T�u�{�X�̍ŏ��̓������~�߂�֐�
    /// </summary>
    public void StopSubBossFirstMove()
    {
        stopSubBossFirstMoveCount = 1;
    }

    /// <summary>
    /// �T�u�{�X�̍ŏ��̓������\������R���[�`��
    /// </summary>
    private IEnumerator FirstMove()
    {
        while(true)
        {
            if(stopSubBossFirstMoveCount == 1)
            {
                this.transform.position = new Vector3(-4, 3, 0);
                yield break;
            }
            changeJudge = Random.value * 2;
            if(changeJudge < 1)
            {
                changeXPosition = -1;
            }
            else
            {
                changeXPosition = 1;
            }

            this.transform.position = new Vector3(Random.value * 4 * changeXPosition, Random.value * 4, 0);
            Instantiate(AimPlayerEnemyBullet, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
