using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] Text text;

    public void SetData(string message)
    {
        text.text = message;
    }

    public void OnClose() //ÆË¾÷ ´Ý±â
    {
        gameObject.SetActive(false);
    }

    
}
