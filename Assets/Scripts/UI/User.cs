using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///ユーザ名とユーザスコアを持つクラス
///</summary>
public class User
{
public int UserScore{get;set;}
public string UserName{get;set;}
public User(int score,string name){
    this.UserScore=score;
    this.UserName=name;
    }
}
