using UnityEngine;
using Photon.Pun;

//�ڵ����� �ʿ��� ������Ʈ�� �ٿ���
[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] GameObject PausegameObject;

    private void Awake()
    {
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
        if (photonView.IsMine == false) return;

        //�ӽ�
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            //�ӽ�
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
        //���� �÷��̾ �� �ڽ��̶��
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
