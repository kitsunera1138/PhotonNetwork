using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks
{
    //��ε� ĳ��Ʈ ��� ��� - ��� �÷��̾�� �޼����� ����


    //�÷��̾ ������ �� ȣ��Ǵ� �Լ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Execute();
        //Debug.Log(newPlayer.NickName);
    }
    //Ŀ�������� ���� �¸�,�й� �޼��� �ִ� �͵� ������
    public void Execute()
    {
        byte stateCode = 1;
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 3)
        {
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions {
            //���� �����ϰ� ���� Ŭ���̾�Ʈ ���� ����
            Receivers = ReceiverGroup.All
            };

            PhotonNetwork.RaiseEvent(stateCode,null, raiseEventOptions,SendOptions.SendReliable);
            //Debug.Log("����");
        }
    }
}
