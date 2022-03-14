using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾の色をちょっとずつ変えていくクラス
/// </summary>
public class EnemyBulletRainBowChange : MonoBehaviour
{
    /// <summary>
    /// 色を変えるメソッド
    /// TODO:色変わらない…
    /// </summary>
    public void ChangeEnemyBullet(Renderer renderer)
    {
        switch (Time.time % 9)
        {
            case 0:
                renderer.material.color = Color.red;
                break;
            case 1:
                renderer.material.color = Color.blue;
                break;
            case 2:
                renderer.material.color = Color.green;
                break;
            case 3:
                renderer.material.color = Color.cyan;
                break;
            case 4:
                renderer.material.color = Color.yellow;
                break;
            case 5:
                renderer.material.color = Color.magenta;
                break;
            case 6:
                renderer.material.color = Color.grey;
                break;
            case 7:
                renderer.material.color = Color.white;
                break;
            case 8:
                renderer.material.color = Color.black;
                break;
        }
    }
}
