using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEditor.VersionControl;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTranform;
    [SerializeField] ScrollRect scrollRect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Enter
        {
            //inputField 활성화
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) { return; }

            //inputField에 있는 텍스트를 가져옵니다.
            //(string 변수) <- Photon 닉네임 + : + inputField에 설정한 문자열
            //문제점 다른사람의 이름이 자신의 이름으로 나타남
            //string talk = photonView.Owner.NickName + " : " + inputField.text;

            //자신의 고유의 이름을 전달해야 채팅창에 다른사람의 이름이 나타남 
            string talk = PhotonNetwork.LocalPlayer.NickName + " : " + inputField.text;

            //RPC Target.All : 현재 룸에 있는 모든 클라이언트에게 Talk() 함수를 실행하라는 명령을 전달합니다.
            photonView.RPC("Talk", RpcTarget.All, talk);//보내고자하는 함수 이름, 타켓

        }
    }
    [PunRPC]
    public void Talk(string message)
    {
        //Prefab을 하나 생성한 다음 text 값을 설정합니다.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));
        //어짜피 photonView.RPC보내기 때문에 그냥 Instantiate 써도됨
        //GameObject text = PhotonNetwork.InstantiateRoomObject("String", Vector3.zero, Quaternion.identity);

        //prefab 오브젝트의 Text 컴포넌트로 접근해서 text 값을 설정합니다.
        talk.GetComponent<Text>().text = message;
        //스크롤 뷰 - content 오브젝트의 자식으로 등록합니다.
        talk.transform.SetParent(parentTranform);
        //채팅을 입력한 후에도 이어서 입력할 수 있도록 설정합니다.
        inputField.ActivateInputField();
        //스크롤 위치를 초기화합니다.
        scrollRect.verticalNormalizedPosition = 0.0f;
        //inputField의 텍스트를 초기화 합니다.
        inputField.text = "";

    }
}
