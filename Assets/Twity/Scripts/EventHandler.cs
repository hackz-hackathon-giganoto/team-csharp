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
        Twity.Oauth.consumerKey = "elhOFaWsttCW9JZS2EJs7iejt";
        Twity.Oauth.consumerSecret = "v9Kjqo9erLtqssGmfF3IuTSzlsKlMHQQzIKFZMQ26LfYiLd84m";
        Twity.Oauth.accessToken = "1500114075610906625-hTIWx7118QkgQo99q45PVZW7sCBqUL";
        Twity.Oauth.accessTokenSecret = "2r8aDPqVGSHKCGCq9emH9oTkyGjW9ViCsmijtk81LpVfM";
    }
}
