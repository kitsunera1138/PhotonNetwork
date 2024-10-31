using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class UnitManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

     void Start()
    {
        //마스터 클라이언트 일 경우
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }

    public IEnumerator Create()
    {
        while (true) 
        {
            //InstantiateRoomObject 룸에 들어오면 오브젝트를 생성함.
            //InstantiateRoomObject(Resources폴더 안 오브젝트 이름, transform,rotation);
            PhotonNetwork.InstantiateRoomObject("Rake",  Vector3.zero, Quaternion.identity);
            yield return waitForSeconds;
        }
    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }
}
