using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNametext;
    // Start is called before the first frame update
    void Start()
    {
        nickNametext.text = photonView.Owner.NickName;
    }
}
