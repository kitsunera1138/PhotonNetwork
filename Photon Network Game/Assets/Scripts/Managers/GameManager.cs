using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks
{
    //브로드 캐스트 방식 사용 - 모든 플레이어에게 메세지를 보냄


    //플레이어가 들어왔을 때 호출되는 함수
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Execute();
        //Debug.Log(newPlayer.NickName);
    }
    //커스텀으로 게임 승리,패배 메세지 주는 것도 가능함
    public void Execute()
    {
        byte stateCode = 1;
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 3)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions {
            //내가 전달하고 싶은 클라이언트 선택 가능
            Receivers = ReceiverGroup.All
            };

            PhotonNetwork.RaiseEvent(stateCode,null, raiseEventOptions,SendOptions.SendReliable);
            //Debug.Log("시작");
        }
    }
}
