using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
    /// <summary>
    /// スコアを管理し表示するクラス
    /// </summay>
 public class ScoreManager : MonoBehaviour
 {
    public static ScoreManager instance = null;
    [SerializeField] GameObject scoreObject;
    private TextMeshProUGUI scoreTMP;
    private int score = 0;
    private void Awake()
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
        scoreTMP =  scoreObject.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// 渡した増分スコアに加算し表示しテキストオブジェクトで表示させるメソッド
    /// </summary>
    public void IncreaseScore(int changeScore)
    {
    score += changeScore;
    scoreTMP.text=score.ToString(); //スコアアニメーションのメソッドを作って後で呼ぶ
    }
 }
 