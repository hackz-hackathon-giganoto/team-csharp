using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] PlayfabDataGateWay gateway;
    [SerializeField] string firstUserName;
    private List<User> rankingUserList;
    private List<User> localUserList;
    private User nowPlayer;
    /*public void Awake(){
        gateway.Initialize();
        nowPlayer = new User (0,firstUserName);
    
    }*/
    public void UpdateRankingPanel(int score){
        nowPlayer.UserScore = score;
        localUserList = rankingUserList;
        localUserList.Add(nowPlayer);
        localUserList.OrderByDescending(user =>user.UserScore);

        int playerIndex = localUserList
            .Select((p,i)=>new {user = p,index = i})
            .Where((a => a.user.UserName == firstUserName))
            .Select(player=>player.index)
            .First();
        
        for(int i = playerIndex - 2;i < 5;i++){
            Debug.Log(localUserList.ElementAt(i).UserName);
        } 
    }
}
