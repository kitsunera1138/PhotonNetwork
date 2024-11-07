using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public enum PopupType
{
    //SIGNINFAILURE,
    //SIGNUPFAILURE,
    SIGNUP,
    PAUSE,
    TEXT,
}

public class PopUpManager : MonoBehaviour
{
    private static PopUpManager instance;
    public static PopUpManager Instance { get { return instance; } }

    private Dictionary<PopupType, GameObject> dictionary = new Dictionary<PopupType, GameObject>();

    [SerializeField] Transform parentTransform;

    private void Awake()
    {
        //if (parentTransform == null || parentTransform.gameObject == null || !parentTransform.gameObject.activeInHierarchy)
        //    parentTransform = gameObject.transform;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Show(PopupType popupType, string content)
    {
        GameObject popup = null;

        //tryGetValue로 key값을 찾는다
        if (dictionary.TryGetValue(popupType, out popup))
        {
            //있다면 게임 오브젝트를 true
            popup.gameObject.SetActive(true);
        }
        else
        {
            //없다면 게임 오브젝트 생성
            popup = Instantiate(Resources.Load<GameObject>(popupType.ToString()));
            // 부모 위치 설정
            popup.transform.SetParent(parentTransform);
            //로컬 포지션으로 설정
            popup.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);

            //PopUp컴포넌트를 가져온 다음 SetData() 함수 호출
            //popup.GetComponent<PopUp>().SetData(content);
            //Dictionary에 추가
            dictionary.Add(popupType, popup);
        }
    }
}
