using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾の色をちょっとずつ変えていくクラス
/// </summary>
public class EnemyBulletRainBowChange : MonoBehaviour
{
    [SerializeField]
    private Renderer rend;

    /// <summary>
    /// 色を変えるメソッド
    /// TODO:色変わらない…
    /// </summary>
    public void Start()
    {
        switch (Time.time % 9)
        {
            case 0:
                rend.material.color = Color.red;
                break;
            case 1:
                rend.material.color = Color.blue;
                break;
            case 2:
                rend.material.color = Color.green;
                break;
            case 3:
                rend.material.color = Color.cyan;
                break;
            case 4:
                rend.material.color = Color.yellow;
                break;
            case 5:
                rend.material.color = Color.magenta;
                break;
            case 6:
                rend.material.color = Color.grey;
                break;
            case 7:
                rend.material.color = Color.white;
                break;
            case 8:
                rend.material.color = Color.black;
                break;
        }
    }
}
