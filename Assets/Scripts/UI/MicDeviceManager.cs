using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 音声入力デバイスを選択、Scene移行時にGetterPitchNumberに渡します
/// </summary>
public class MicDeviceManager : MonoBehaviour
{
    [SerializeField] private Dropdown micDropdown;
    private string micDevice;

    public void Awake(){
        GetMicDevices();
        SceneManager.sceneLoaded += SetMicDevice;
    }

    /// <summary>
    /// 音声入力デバイスを取得、ドロップダウンリストに追加
    /// </summary>
    private void GetMicDevices()
    {
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            micDropdown.options.Add(new Dropdown.OptionData { text = Microphone.devices[i] });
        }
        micDevice =  Microphone.devices[0];
    }
    /// <summary>
    /// OnValueChangedで呼び出し
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
        GetterPitch pitchManager = GameObject.FindWithTag("PitchManager").GetComponent<GetterPitch>();
        pitchManager.DeviceName = micDevice;
    }
}
