using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCamera()
    {
        //���� �÷��̾ �� �ڽ��̶��
        if (photonView.IsMine)
        {
            Camera.main.enabled = false;
            

        }
        else
        {

        }
    }
}
