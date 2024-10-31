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
    private Dictionary<string, GameObject> dictonary = new Dictionary<string, GameObject>();

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
        GameObject roomPrefab;
        foreach (RoomInfo room in roomList)
        {
            //���� ������ ���
            if (room.RemovedFromList == true)
            {
                dictonary.TryGetValue(room.Name, out roomPrefab);
                //����� ����
                Destroy(roomPrefab);
                dictonary.Remove(room.Name);
            }
            else //���� ������ ����� ��� 
            {
                //���� ó�� ������ ���
                if (dictonary.ContainsKey(room.Name) == false) //ã�� ���� ���ٸ�
                {
                    GameObject roomObject = InstantiateRoom();

                    roomObject.GetComponent<Information>().SetData(
                        room.Name,
                        room.PlayerCount,
                        room.MaxPlayers
                        );

                    dictonary.Add(room.Name, roomObject);
                }
                else //���� ������ ����� ���
                {
                    dictonary.TryGetValue(room.Name, out roomPrefab);

                    roomPrefab.GetComponent<Information>().SetData
                    (
                        room.Name,
                        room.PlayerCount,
                        room.MaxPlayers
                    );

                }
            }
        }
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