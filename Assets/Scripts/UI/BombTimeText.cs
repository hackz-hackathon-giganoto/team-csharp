using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombTimeText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int textSize;
    public void SetBombText(float bombTime){
        text.text = bombTime.ToString($"0.'<size={textSize}%>'00");
    }
}
