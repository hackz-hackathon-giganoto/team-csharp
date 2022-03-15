using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 音量によってスライダーの割合を変えるクラス
/// </summary>
public class VolumeSlider : MonoBehaviour
{   
    [SerializeField] GetterPitch getterPitch;
    [SerializeField] Slider volumeSlider;
    [SerializeField] float MaxVolume;
    private void FixedUpdate() {
        volumeSlider.value = getterPitch.pitchHighest / MaxVolume;
    }
}
