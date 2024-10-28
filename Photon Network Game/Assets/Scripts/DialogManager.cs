using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEditor.VersionControl;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTranform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Enter
        {
            //inputField Ȱ��ȭ
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) { return; }

            //inputField�� �ִ� �ؽ�Ʈ�� �����ɴϴ�.
            //(string ����) <- Photon �г��� + : + inputField�� ������ ���ڿ�
            string talk = photonView.Owner.NickName + " : " + inputField.text;

            //RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk() �Լ��� �����϶�� ����� �����մϴ�.
            photonView.RPC("Talk", RpcTarget.All, talk);//���������ϴ� �Լ� �̸�, Ÿ��

        }
    }
    [PunRPC]
    public void Talk(string message)
    {
        //Prefab�� �ϳ� ������ ���� text ���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));
        //��¥�� photonView.RPC������ ������ �׳� Instantiate �ᵵ��
        //GameObject text = PhotonNetwork.InstantiateRoomObject("String", Vector3.zero, Quaternion.identity);

        //prefab ������Ʈ�� Text ������Ʈ�� �����ؼ� text ���� �����մϴ�.
        talk.GetComponent<Text>().text = message;
        //��ũ�� �� - content ������Ʈ�� �ڽ����� ����մϴ�.
        talk.transform.SetParent(parentTranform);
        //ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField();
        //inputField�� �ؽ�Ʈ�� �ʱ�ȭ �մϴ�.
        inputField.text = "";
    }
}
