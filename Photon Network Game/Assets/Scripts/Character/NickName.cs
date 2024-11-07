using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNametext;
    [SerializeField] Camera remoteCamera;
    private void Awake()
    {
        //1.PhotonNetwork.NickName�� ����� String ���� �ҷ��ɴϴ�.
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");
    }
    void Start()
    {
        remoteCamera = Camera.main;
        nickNametext.text = photonView.Owner.NickName;
    }

    private void Update()
    {
        transform.forward = remoteCamera.transform.forward;
        /*
        transform.LookAt(remoteCamera.transform.localPosition);
        Vector3 euler = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(0, euler.y, 0);
        */
        //���� �ؿ���

        //Vector3 direction = remoteCamera.transform.position - transform.position;
        //direction.y = 0;
        //transform.LookAt(direction);
    }
}
