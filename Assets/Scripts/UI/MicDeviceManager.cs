using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 音声入力デバイスを選択、Scene移行時にGetterPitchNumberに渡すクラス
/// </summary>
public class MicDeviceManager : MonoBehaviour
{
    [SerializeField] Dropdown micDropdown;
    private string micDevice;

    public void Awake(){
        CreateMicDevicesDropDown();
        micDropdown.onValueChanged.AddListener((value) => SelectMicDevice());
        SceneManager.sceneLoaded += SetMicDevice;
    }

    /// <summary>
    /// 音声入力デバイスを取得、ドロップダウンリストに追加
    /// TODO:Microphone.devices.Lengthが0の時警告モーダルを出す
    /// </summary>
    private void CreateMicDevicesDropDown()
    {
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            micDropdown.options.Add(new Dropdown.OptionData { text = Microphone.devices[i] });
        }
        micDevice =  Microphone.devices[0];
    }

    /// <summary>
    /// micDeviceに選択したデバイス名を代入
    /// </summary>
    public void SelectMicDevice()
    {
        micDevice = micDropdown.captionText.text;

    }
    /// <summary>
    /// Scene移行時pItchManagerタグの付いたオブジェクトにmicDeviceを渡す
    /// </summary>
    private void SetMicDevice(Scene next,LoadSceneMode mode){
        if(next.name != "Main"){
            return;
            }
        GetterPitch pitchManager = GameObject.FindWithTag("pitchManager").GetComponent<GetterPitch>();
        pitchManager.DeviceName = micDevice;
    }

}
