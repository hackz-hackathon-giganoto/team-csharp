using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///アイコンを表示するクラス
///</summary>
public class IconPanel : MonoBehaviour
{
    [SerializeField]GameObject iconObj;
    ///<summary>
    ///引数分のアイコンを表示するメソッド
    ///</summary>
    public void SetIcon(int count) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < count; i++) {
            Instantiate<GameObject>(iconObj, transform);
        }
    }
    /// <summary>
    /// アイコンの表示が一つ増えるメソッド
    /// </summary>
    public void IncreseIcon(){
        Instantiate<GameObject>(iconObj, transform).transform.localScale = new Vector3(0f,0f,1f);
        int childNum = transform.childCount;
        transform.GetChild(childNum-1).GetComponent<IconAnimation>().AppearIcon();
    }

    /// <summary>
    /// アイコンの表示が一つ消えるメソッド
    /// </summary>
    public void DecreseIcon(){
        int childNum = transform.childCount;
        transform.GetChild(childNum-1).GetComponent<IconAnimation>().VanishIcon();
    }
}
