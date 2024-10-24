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
        //������ Ŭ���̾�Ʈ �� ���
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }

    public IEnumerator Create()
    {
        while (true) 
        {
            //InstantiateRoomObject �뿡 ������ ������Ʈ�� ������.
            //InstantiateRoomObject(Resources���� �� ������Ʈ �̸�, transform,rotation);
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
