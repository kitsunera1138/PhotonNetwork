using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

//자동으로 필요한 컴포넌트를 붙여줌
[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]

public class Character : MonoBehaviourPunCallbacks
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] GameObject PausegameObject;

    //private EventData eventData;

    private void Awake()
    {
        //eventData = new EventData(); //MonoBehaviour 상속이 안되기에 new로 할당(생성)
        rigidBody = GetComponent<Rigidbody>();
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
    }
    void Start()
    {
        DisableCamera();
    }


    void Update()
    {
        //if (eventData.Code != 1) { return; }
        if (photonView.IsMine == false) return;

        //임시
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            //임시
            PausegameObject = GameObject.Find("Canvas").transform.Find("Pause Panel").gameObject;
            PausegameObject.SetActive(true);
        }

        move.OnKeyUpdate();
        rotation.OnKeyUpdate();
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine == false) return;

        move.OnMove(rigidBody);
        rotation.RotateY(rigidBody);
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

    //public void OnEvent(EventData photonEvent)
    //{
    //    switch (photonEvent.Code)
    //    {
    //        case 0:
    //            break;


            
    //    }
    //}
    
}
