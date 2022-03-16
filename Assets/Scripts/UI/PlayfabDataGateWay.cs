using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

///<summary>
///Playfabのランキングデータを管理するクラス
///</summary>
public class PlayfabDataGateway : MonoBehaviour
{
    public void Initialize(){
        PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true},
            result => Debug.Log("ログイン成功"),
            ((error) => Debug.Log($"ログイン失敗{error.ErrorMessage}"))
        );
    }
    /// <summary>
    /// プレイヤー名をセットするメソッド
    /// </summary>
    public void SetUserName(string playerName)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playerName
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        ((result)=>Debug.Log("プレイヤー名セット成功")),
        ((error)=>Debug.Log($"{error.Error}"))
        );
    }
    /// <summary>
    /// スコアを登録するメソッド
    /// </summary>
    public void SubmitScore(int score)
    {
        var statisticUpdate = new StatisticUpdate
        {
            StatisticName = "HighScore",
            Value = score,
        };
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                statisticUpdate
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,
        ((result)=>Debug.Log("スコア送信成功")),
        ((error)=> Debug.Log($"{error.Error}"))
        );
    }
    /// <summary>
    /// ランキング降順のUser型リストを返すメソッド
    /// </summary>
    public List<User> GetUserList()
    {
        List<User> rankingUserList = null;
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
                Debug.Log($"{rankingUserList.Last().UserScore}位:{rankingUserList.Last().UserName}さん");
            };
        },
        error=>{
            Debug.Log($"{error.Error}");
        }
        );
        return rankingUserList;
    }
}
