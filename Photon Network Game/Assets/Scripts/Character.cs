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
        move.OnKeyUpdate();
        rotation.OnKeyUpdate();
    }
    private void FixedUpdate()
    {
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
