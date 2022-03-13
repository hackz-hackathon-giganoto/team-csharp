using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///アイコンを表示するクラス
    ///</summary>
public class IconPanel : MonoBehaviour
{
    [SerializeField]private GameObject iconObj;
    [SerializeField]private int firstCount;
    ///<summary>
    ///引数分のアイコンを表示
    ///</summary>
    public void SetIcon(int count) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < count; i++) {
            Instantiate<GameObject>(iconObj, transform);
        }
    }
    public void DecreseCount(){
        int childNum = transform.childCount;
        //Destroy(transform.GetChild(childNum-1).gameObject);
        
    }
}
