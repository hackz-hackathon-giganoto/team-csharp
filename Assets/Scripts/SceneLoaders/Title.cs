using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class Title : SceneBase {
    [SerializeField] Dropdown deviceDropDown;

    public void GoMain(){
        string deviceName = deviceDropDown.captionText.text;
        SimpleSceneNavigator.Instance.GoForwardAsync<Main>(new Main.Options(deviceName)).Forget();
    }
}
