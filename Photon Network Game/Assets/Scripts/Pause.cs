using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Pause : PopUp
{
    public override void OnConfirm()
    {
        MouseManager.Instance.SetMouse(false);
        gameObject.SetActive(false);
    }

    // PopUp Ŭ���� ��� �޾Ƽ� ���
    //public void Resume() {
    //    MouseManager.Instance.SetMouse(false);
    //    gameObject.SetActive(false);
    //}

    public void Exit() {
        PhotonNetwork.LeaveRoom();
        gameObject.SetActive(false);

    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }
}
