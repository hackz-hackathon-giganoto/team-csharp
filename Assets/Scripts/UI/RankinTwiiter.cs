using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

/// <summary>
/// ランキングを表示するスクリプト
/// </summary>

public class RankinTwiiter : MonoBehaviour {

  [SerializeField]
  private string rankingText = default;
  [SerializeField]
  AutomaticTweet twitter;
  public string RankingText{get;set;}
    [SerializeField] ResultScene result;

  public void Initialize()
  {
    RankingUserLogin();
  }

  public void GetLeaderboard() { 
    var request = new GetLeaderboardRequest{
      StatisticName   = "shiiRanking",
      StartPosition   = 0,
      MaxResultsCount = 1  
    };

    Debug.Log($"ランキング(リーダーボード)の取得開始");
    PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
  }
  
  private void OnGetLeaderboardSuccess(GetLeaderboardResult result){
    Debug.Log($"ランキング(リーダーボード)の取得に成功しました");
    int count=0;
    foreach (var entry in result.Leaderboard) {
      rankingText += $"{entry.Position + 1}位  {entry.DisplayName}:スコア{entry.StatValue}\n\n";
      Debug.Log(rankingText);
      count++;
        if(count ==3)break;
    }
    OnComplete(rankingText);
  }
  private void OnComplete(string tweetText) {
      twitter.TweetAuto(tweetText);
      Thread.Sleep(2000);
      result.GoTitle();
  }

  private void OnGetLeaderboardFailure(PlayFabError error){
    Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
    rankingText += "ランキングの取得に失敗しました\nタイトルに戻って再度お試しください";
  }
  public void RankingUserLogin()
  {
      PlayFabClientAPI.LoginWithCustomID(
        new LoginWithCustomIDRequest { CustomId = "ranker", CreateAccount = true},
          result => 
          {
            Debug.Log("ログイン成功！");
            GetLeaderboard();
          },
          error => 
          {
            Debug.Log("ログイン失敗");
          }
      );
  }
}