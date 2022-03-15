using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : SceneBase
{
    [SerializeField] Text scoreText;
    [SerializeField] Text grazeText;
    public class Options {
        public Options (int score,int graze) {
            this.Score = score;
            this.Graze = graze;
        }
        public int Score { get; private set; }
        public int Graze { get; private set; }
    }

    public override void OnLoad (object options) {
        var op = options as Options;
        scoreText.text = op.Score.ToString();
        grazeText.text = op.Graze.ToString();
    }
}
