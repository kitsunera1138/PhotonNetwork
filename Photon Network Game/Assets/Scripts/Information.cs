using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Information : MonoBehaviourPunCallbacks
{
    private string roomName;

    [SerializeField] Text roomTitleText;

    public void OnConnectRoom()
    {
        //join�� ��� �ش��ϴ� roomName���� ��
        PhotonNetwork.JoinRoom(roomName);
    }

    //SetData(�̸�,�����ο���,�ִ� �ο���)
    public void SetData(string roomName, int currentStaff, int maxStaff)
    {
        this.roomName = roomName;

        roomTitleText.text = roomName + " ( " + currentStaff + " / " + maxStaff + " ) ";
    }
}
