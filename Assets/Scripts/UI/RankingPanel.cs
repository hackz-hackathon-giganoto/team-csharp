using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] PlayfabDataGateway gateway;
    [SerializeField] string firstUserName;
    private List<User> rankingUserList;
    private List<User> localUserList;
    private User player;
    public void Initialize(){
        gateway.Initialize();
        rankingUserList = gateway.GetUserList();
        player = new User (0,firstUserName);
    }
    public void UpdateRankingPanel(){
        localUserList = rankingUserList;
        localUserList.Add(player);
        localUserList.OrderByDescending(u =>u.UserScore);
    }
}
