using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using WebSocketSharp;

public class NickNameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    [SerializeField] InputField inputField;
    [SerializeField] GameObject nickNamePanel;

    void Start()
    {
        //1.PhotonNetwork.NickName에 저장된 String 값을 불러옵니다.
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        //2. PhotonNetwork.NickName 비어 있다면 nickNamePanel을 활성화 합니다.
        if (PhotonNetwork.NickName.IsNullOrEmpty())
        {
            nickNamePanel.SetActive(true);
        }
    }

    public void OnSetNickName()
    {
        //1. PhotonNetwork.NickName에 inputField로 입력한 값을 넣어줍니다.
        PhotonNetwork.NickName = inputField.text;
        //2. NickName을 저장합니다.
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);
        //3. 게임 오브젝트를 비활성화 합니다.
        nickNamePanel.SetActive(false);
    }
}
