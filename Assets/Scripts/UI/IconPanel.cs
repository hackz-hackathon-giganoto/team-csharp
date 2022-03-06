 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class IconPanel : MonoBehaviour
{
    [SerializeField]private GameObject IconObj;
    [SerializeField]private int firstSetNum;
    private void Start(){
        SetIcon(firstSetNum);
    }
    
    ///<summary>
    ///渡した引数分のアイコンを表示します
    ///</summary>
    public void SetIcon(int setNum) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < setNum; i++) {
            Instantiate<GameObject>(IconObj, transform);
        }
    }
}
