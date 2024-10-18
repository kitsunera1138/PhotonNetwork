using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform parentTransform;
    [SerializeField] InputField roomNameInputField;
    [SerializeField] InputField roomCapacityInputField;

    //�������� �Ҵ��ؼ� ����� ����
    private Dictionary<string, RoomInfo> dictonary = new Dictionary<string, RoomInfo>();
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        //�ִ� �ο� ���� �� �� ����
        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        InstantiateRoom();
    }

    public GameObject InstantiateRoom()
    {
        //1. Room ������Ʈ�� �����մϴ�.
        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));
        //2. Room ������Ʈ�� �θ� ��ġ�� �����մϴ�.
        room.transform.SetParent(parentTransform);
        //3. Room ������Ʈ�� ��ȯ �մϴ�.
        return room;
    }
}