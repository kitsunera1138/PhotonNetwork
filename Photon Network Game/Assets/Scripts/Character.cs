using UnityEngine;
using Photon.Pun;

//자동으로 필요한 컴포넌트를 붙여줌
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
