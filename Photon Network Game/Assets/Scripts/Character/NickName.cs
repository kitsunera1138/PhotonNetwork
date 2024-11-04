using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNametext;
    [SerializeField] Camera remoteCamera;

    void Start()
    {
        nickNametext.text = photonView.Owner.NickName;
    }

    private void Update()
    {
        transform.LookAt(remoteCamera.transform.localPosition);
        Vector3 euler = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(0, euler.y, 0);

        //À§¿Í ¹Ø¿¡²¨

        //Vector3 direction = remoteCamera.transform.position - transform.position;
        //direction.y = 0;
        //transform.LookAt(direction);
    }
}
