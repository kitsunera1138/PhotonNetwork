using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public abstract class PopUp : MonoBehaviourPunCallbacks
{
    public abstract void OnConfirm();
    //[SerializeField] Text text;

    //public void SetData(string message)
    //{
    //    text.text = message;
    //}

    //public void OnClose() //ÆË¾÷ ´Ý±â
    //{
    //    gameObject.SetActive(false);
    //}

    
}
