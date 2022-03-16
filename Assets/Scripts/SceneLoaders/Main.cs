using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;    

public class Main : SceneBase {
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GetterPitch getterPitch;


    public class Options {
        public Options (string micDeviceName) {
            this.micDevice = micDeviceName;
        }
        public string micDevice { get; private set; }
    }

    public override void OnLoad (object options) {
        var op = options as Options;
        getterPitch.DeviceName = op.micDevice;
    }
    public void GoResult () => SimpleSceneNavigator.Instance.GoForwardAsync<ResultScene> (new ResultScene.Options(scoreManager.Score)).Forget();
}
