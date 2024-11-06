using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : PopUp //TextPopup
{
    [SerializeField] Text text;
    public override void OnConfirm()
    {
        gameObject.SetActive(false);
    }
}
