using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾が円状に出るスクリプト
/// </summary>
public class EnemyBulletRotationShot : MonoBehaviour
{
    [SerializeField]
    private GameObject firstEnemyBullet;
    [SerializeField]
    private GameObject secondEnemyBullet;

    [SerializeField]
    private float generationIntervalSeconds;
    [SerializeField]
    private float rotationInterval;
    [SerializeField]
    private float generationIntervalSecondsAcceleration;
    [SerializeField]
    private float generationRotationIntervalSeconds;
    [SerializeField]
    private float rotationSpeed;

    private float rotationAcceleration;

    [SerializeField]
    private int firstRotationCount;
    [SerializeField]
    private int secondRotationCount; 

    private bool stopFirstShotPattern;
    private bool stopSecondShotPattern;

    void Start()
    {
        rotationAcceleration = rotationSpeed;

        stopFirstShotPattern = false;
        stopSecondShotPattern = false;
    }

    /// <summary>
    /// コルーチンを呼び出す関数
    /// </summary>
    public void CallFirstShotPattern()
    {
        StartCoroutine(FirstShotPattern());
    }
    public void CallSecondShotPattern()
    {
        StartCoroutine(SecondShotPattern());
    }
    public void StopFirstShotPattern()
    {
        stopFirstShotPattern = true;
    }
    public void StopSecondShotPattern()
    {
        stopSecondShotPattern = true;
    }


    /// <summary>
    /// 敵の弾を出すコルーチン
    /// </summary>
    private IEnumerator FirstShotPattern()
    {
        for(int i = 0 ; i < firstRotationCount; i++)
        {
            for (float j = 0; j < 360; j += rotationInterval)
            {
                if(stopFirstShotPattern)
                {
                    yield break;
                }
                Instantiate(
                    firstEnemyBullet,
                    new Vector3(this.transform.position.x,this.transform.position.y,1),
                    Quaternion.Euler(0, 0, j + rotationSpeed)
                );
                yield return new WaitForSeconds(generationIntervalSeconds);
            }
            yield return new WaitForSeconds(generationRotationIntervalSeconds);

            rotationSpeed += rotationAcceleration;

            generationIntervalSeconds -= generationIntervalSecondsAcceleration;
        }
    }

    /// <summary>
    /// 敵の弾を出すコルーチン
    /// </summary>
    private IEnumerator SecondShotPattern()
    {
        for (int i = 0; i < secondRotationCount; i++)
        {
            for (float j = 0; j < 360; j += rotationInterval)
            {
                if(stopSecondShotPattern)
                {
                    yield break;
                }
                Instantiate(
                    secondEnemyBullet,
                    new Vector3(this.transform.position.x, this.transform.position.y, 1),
                    Quaternion.Euler(0, 0, j)
                );
                yield return new WaitForSeconds(generationIntervalSeconds);

                generationIntervalSeconds -= generationIntervalSecondsAcceleration;
            }
            yield return new WaitForSeconds(generationRotationIntervalSeconds);
        }
    }
}
