using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Information : MonoBehaviourPunCallbacks
{
    private string roomName;

    [SerializeField] Text roomTitleText;

    public void OnConnectRoom()
    {
        //join할 경우 해당하는 roomName으로 들어감
        PhotonNetwork.JoinRoom(roomName);
    }

    //SetData(이름,현재인원수,최대 인원수)
    public void SetData(string roomName, int currentStaff, int maxStaff)
    {
        this.roomName = roomName;

        roomTitleText.text = roomName + " ( " + currentStaff + " / " + maxStaff + " ) ";
    }
}
