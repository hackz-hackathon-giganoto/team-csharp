 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class IconPanel : MonoBehaviour
{
    [SerializeField]private GameObject IconObj;
    private void Start(){
        SetIcon(3);
    }
    public void SetIcon(int life) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < life; i++) {
            Instantiate<GameObject>(IconObj, transform);
        }
    }
}
