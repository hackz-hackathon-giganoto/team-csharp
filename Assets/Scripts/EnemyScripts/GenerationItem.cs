using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// スコアアップアイテムとパワーアップアイテムをランダムに生成するクラス。
/// </summary>
public class GenerationItem : MonoBehaviour
{
    
    [SerializeField]
    private GameObject scoreUpItem;
    [SerializeField]
    private GameObject powerUpItem;
    /// <summary>
    /// スコアアップアイテムとパワーアップアイテムをランダムに生成する。
    /// </summary>
    public void Generation() 
        {
            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                Instantiate(scoreUpItem, this.gameObject.transform.position, Quaternion.identity);
            }else
            {
                Instantiate(powerUpItem, this.gameObject.transform.position, Quaternion.identity);
            }
        }
}
