using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEditor.PackageManager.Requests;


public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField emailInputField;
    [SerializeField] InputField passwordInputField;

    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Lobby Scene");
    }

    //회원 가입에 성공 했을때 호출되는 콜백함수 
    //public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    //{
    //    Debug.Log(registerPlayFabUserResult.Request);
    //    Debug.Log(registerPlayFabUserResult.ToString());
    //}
    public void Failure(PlayFabError playFabError)
    {
        //PopUpManager.Instance.Show(PopupType.SIGNUPFAILURE,playFabError.GenerateErrorReport());
        PopUpManager.Instance.Show(PopupType.TEXT,playFabError.GenerateErrorReport());
        //Debug.Log(playFabError.GenerateErrorReport());
    }

    //로그인 함수
    public void OnSignIn()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(
            request,
            Success,
            Failure
            );
    }

    public void OnSighUp()
    {
        PopUpManager.Instance.Show(PopupType.SIGNUP, "OnSIGNUP");//OnSighUp임시
        //SignUp 클래스로 넣음
        //var request = new RegisterPlayFabUserRequest
        //{
        //    Email = emailInputField.text,
        //    Password = passwordInputField.text,
        //    RequireBothUsernameAndEmail = false
        //};

        //PlayFabClientAPI.RegisterPlayFabUser(
        //    request,
        //    Success,
        //    Failure
        //    );
    }


}
