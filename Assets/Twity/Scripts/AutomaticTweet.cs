using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Core;

/// <summary>
/// 自動ツイート機能のクラス
/// </summary>
public class AutomaticTweet : MonoBehaviour
{
    [SerializeField]
    string tweetText;
    public void TweetAuto()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["status"] = tweetText;
        StartCoroutine(Twity.Client.Post("statuses/update", parameters, Callback));
    }

    /// <summary>
    /// ツイートの成功失敗をコールバックする
    /// </summary>
    void Callback(bool success, string response)
    {
        if (success)
        {
            Tweet tweet = JsonUtility.FromJson<Tweet>(response);
        }
        else
        {
            Debug.Log(response);
        }
    }
}
