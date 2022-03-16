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

    public void Awake()
    {
        CreateMicDevicesDropDown();
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
    }
}
