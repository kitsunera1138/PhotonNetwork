using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class SignUp : PopUp //SignUpPopUp
{
    [SerializeField] InputField emailInputField;
    [SerializeField] InputField passwordInputField;
    [SerializeField] InputField NickNameInputField;
    public override void OnConfirm()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
            Username = NickNameInputField.text,
        };

        PlayFabClientAPI.RegisterPlayFabUser(
            request,
            Success,
            Failure
            );

        gameObject.SetActive(false);
    }

    //ȸ�� ���Կ� ���� ������ ȣ��Ǵ� �ݹ��Լ� 
    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        Debug.Log(registerPlayFabUserResult.Request);
        Debug.Log(registerPlayFabUserResult.ToString());
    }

    public void Failure(PlayFabError playFabError)
    {
        //PopUpManager.Instance.Show(PopupType.SIGNUPFAILURE,playFabError.GenerateErrorReport());
        PopUpManager.Instance.Show(PopupType.TEXT, playFabError.GenerateErrorReport());
        //Debug.Log(playFabError.GenerateErrorReport());
    }


}
