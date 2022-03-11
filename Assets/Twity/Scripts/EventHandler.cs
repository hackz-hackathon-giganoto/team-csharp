using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// APIKeyを書くクラス
/// TODO:Git側から見えないようにできないか確かめる
/// </summary>
public class EventHandler : MonoBehaviour
{
    void Start()
    {
        Twity.Oauth.consumerKey = "yDWNJ8EfwFkURkhB6Rj2MVa3P";
        Twity.Oauth.consumerSecret = "f0gmkvlpE9n8kaGgVVvazch5Mfb4uhYK0GPie7BOcDf0tkCG4e";
        Twity.Oauth.accessToken = "1500114075610906625-imAXUKaijDnDrDQ4ZG71k6hAJLYZK0";
        Twity.Oauth.accessTokenSecret = "j3bD925nfosTFxE8Qtox3ijrCLPk1tdBU1NgAmtwmdJqJ";
    }
}
