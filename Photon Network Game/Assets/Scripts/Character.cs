using UnityEngine;
using Photon.Pun;

//�ڵ����� �ʿ��� ������Ʈ�� �ٿ���
[RequireComponent(typeof(Move))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Move move;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        move = GetComponent<Move>();
    }
    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        move.OnKeyUpdate();
    }
    private void FixedUpdate()
    {
        move.OnMove(rigidBody);
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
