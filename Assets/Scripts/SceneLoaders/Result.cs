using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : SceneBase
{
    [SerializeField] Text text;
    public class Options {
        public Options (int score) {
            this.Score = score;
        }
        public int Score { get; private set; }
    }

    public override void OnLoad (object options) {
        var op = options as Options;
        text.text = op.Score.ToString();
    }

}
