using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IconAnimation : MonoBehaviour
{
    public void VanishIcon(){
        
        Destroy(this.gameObject);
    }
}
