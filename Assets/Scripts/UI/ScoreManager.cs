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
    private int score;
    private int graze;
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
        score += changeScore;
        scoreTMP.text=score.ToString($"{option}");
    }

    /// <summary>
    /// 渡した増分スコアに加算し表示しテキストオブジェクトで表示させるメソッド
    /// </summary>
    public void IncreaseGreze()
    {
        graze++;
        grazeTMP.text=graze.ToString();
    }
 }
 