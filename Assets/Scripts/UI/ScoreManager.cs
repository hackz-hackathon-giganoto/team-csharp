using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
    /// <summary>
    /// スコアとかすりを管理し表示するクラス
    /// </summay>
 public class ScoreManager : MonoBehaviour
 {
    public static ScoreManager instance = null;
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI grazeTMP;
    [SerializeField,HeaderAttribute("スコア書式(D8で8桁0埋め)")] string option;
    public int Score{get;private set;}
    public int Graze{get;private set;}
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 渡した増分スコアに加算し表示しテキストオブジェクトで表示させるメソッド
    /// </summary>
    public void IncreaseScore(int changeScore)
    {
        Score += changeScore;
        scoreTMP.text=Score.ToString($"{option}");
    }

    /// <summary>
    /// 渡した増分スコアに加算し表示しテキストオブジェクトで表示させるメソッド
    /// </summary>
    public void IncreaseGreze()
    {
        Graze++;
        grazeTMP.text=Graze.ToString();
    }
 }
 