using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;

    // Start is called before the first frame update
    void Start()
    {
        DisableCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCamera()
    {
        //현재 플레이어가 나 자신이라면
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
