using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rotation))]


public class Head : MonoBehaviourPunCallbacks //photonView ���
{
    [SerializeField] Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false) return;

        //�ӽ�
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }


        rotation.RotateX();
    }
}
