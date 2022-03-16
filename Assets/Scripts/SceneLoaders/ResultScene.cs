using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class ResultScene : SceneBase
{
    [SerializeField] Text scoreText;
    [SerializeField] ResultButtonController resultButton;
    public class Options {
        public Options (int score) {
            this.Score = score;
        }
        public int Score { get; private set; }
    }

    public override void OnLoad (object options) {
        var op = options as Options;
        scoreText.text = op.Score.ToString();
        resultButton.Score = op.Score;
    }
    public void GoTitle () => SimpleSceneNavigator.Instance.GoForwardAsync<Title> ().Forget();

}
