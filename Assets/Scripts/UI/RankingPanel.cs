using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///ランキングを表示するクラス
///</summary>
public class RankingPanel : MonoBehaviour
{
    public void  Awake(){

    }

    ///<summary>
    ///ユーザ名とユーザスコアを管理する内部クラス
    ///</summary>
    private class User
    {
    public int UserScore{get;set;}
    public string UserName{get;set;}
    public User(int score,string name){
        this.UserScore=score;
        this.UserName=name;
        }
    }

}
