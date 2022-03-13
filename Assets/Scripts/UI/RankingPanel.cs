using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

///<summary>
///ランキングを表示するクラス
///</summary>
public class RankingPanel : MonoBehaviour
{
    private List<User> rankingUserList;
    public void  Awake(){
        GetRanking();
    }

    private void GetRanking()
    {
        PlayFabClientAPI.GetLeaderboard(
        new GetLeaderboardRequest
        {
            StatisticName = "HighScore", 
            StartPosition = 0, 
            MaxResultsCount = 100 
        },
        result=>
        {
            foreach (var user in result.Leaderboard){
                rankingUserList.Add(new User(user.StatValue,user.DisplayName));
                Debug.Log($"{rankingUserList.Last().UserScore}:{rankingUserList.Last().UserName}さん");
            };
        },
        error=>{
            Debug.Log($"{error.Error}");
        }
        );

  
    }

    ///<summary>
    ///ユーザ名とユーザスコアを管理する内部クラス
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

}
