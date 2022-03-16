using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

///<summary>
///Playfabのランキングデータを管理するクラス
///</summary>
public class PlayfabDataGateWay : MonoBehaviour
{
    [SerializeField]GameObject text;
    [SerializeField]GameObject exitButton;
    private string playerName;
    private int playerScore;
    public void Initialize(string name,int score){
        playerName = name;
        playerScore = score;
        PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = playerName, CreateAccount = true},
            ((result) => SetUserName()),
            ((error) => Debug.Log($"ログイン失敗{error.ErrorMessage}"))
        );
    }
    /// <summary>
    /// プレイヤー名をセットするメソッド
    /// </summary>
    public void SetUserName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playerName
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
        ((result)=>SubmitScore()),
        ((error)=>Debug.Log($"{error.Error}"))
        );
    }
    /// <summary>
    /// スコアを登録するメソッド
    /// </summary>
    public void SubmitScore()
    {
        var statisticUpdate = new StatisticUpdate
        {
            StatisticName = "HighScore",
            Value = playerScore,
        };
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                statisticUpdate
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,
        ((result)=>{text.SetActive(true);exitButton.SetActive(true);}),
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
