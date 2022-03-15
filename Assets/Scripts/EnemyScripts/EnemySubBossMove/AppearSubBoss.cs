using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �T�u�{�X���o�ꂷ�邽�߂̃X�N���v�g
/// </summary>
public class AppearSubBoss : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float goalY;
    [SerializeField] private float stopTime;

    [SerializeField] private Rigidbody2D rb2D;

    [SerializeField] private SubBossFirstMove subBossFirstMoveScript;

    void Start()
    {
        this.rb2D.velocity = new Vector3(0, -moveSpeed, 0);
        StartCoroutine("StopSubBoss");
    }

    /// <summary>
    /// �T�u�{�X��o�ꂳ����֐�
    /// </summary>
    public void StartApperSubBoss()
    {
        this.rb2D.velocity = new Vector3(0, -moveSpeed, 0);
        StartCoroutine("StopSubBoss");
    }

    /// <summary>
    /// �T�u�{�X���~�߂邽�߂̃R���[�`��
    /// </summary>
    private IEnumerator StopSubBoss()
    {
        while (true)
        {
            if(this.transform.position.y <= goalY)
            {
                this.rb2D.velocity = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(stopTime);
                subBossFirstMoveScript.CallSubBossFirstMove();
                yield break;
            }
            yield return null;
        }
        
    }
}
