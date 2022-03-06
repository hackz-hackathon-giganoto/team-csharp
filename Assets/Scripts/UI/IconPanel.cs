using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    ///<summary>
    ///アイコンを表示するクラスです
    ///</summary>
public class IconPanel : MonoBehaviour
{
    [SerializeField]private GameObject iconObj;
    [SerializeField]private int firstCount;
    private void Start(){
        SetIcon(firstCount);
    }

    ///<summary>
    ///渡した引数分のアイコンを表示します
    ///</summary>
    public void SetIcon(int count) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < count; i++) {
            Instantiate<GameObject>(iconObj, transform);
        }
    }
}
