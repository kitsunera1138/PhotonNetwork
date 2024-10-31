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

    //동적으로 할당해서 사용할 예정
    private Dictionary<string, GameObject> dictonary = new Dictionary<string, GameObject>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        //최대 인원 설정 등 방 설정
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
            //룸이 삭제된 경우
            if (room.RemovedFromList == true)
            {
                dictonary.TryGetValue(room.Name, out roomPrefab);
                //빈방을 날림
                Destroy(roomPrefab);
                dictonary.Remove(room.Name);
            }
            else //룸의 정보가 변경된 경우 
            {
                //룸이 처음 생성된 경우
                if (dictonary.ContainsKey(room.Name) == false) //찾는 것이 없다면
                {
                    GameObject roomObject = InstantiateRoom();

                    roomObject.GetComponent<Information>().SetData(
                        room.Name,
                        room.PlayerCount,
                        room.MaxPlayers
                        );

                    dictonary.Add(room.Name, roomObject);
                }
                else //룸의 정보가 변경된 경우
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
        //1. Room 오브젝트를 생성합니다.
        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));
        //2. Room 오브젝트의 부모 위치를 설정합니다.
        room.transform.SetParent(parentTransform);
        //3. Room 오브젝트를 반환 합니다.
        return room;
    }
}