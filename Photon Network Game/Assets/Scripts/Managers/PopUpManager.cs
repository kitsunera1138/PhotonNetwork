using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public enum PopupType
{
    SIGNINFAILURE,
    SIGNUPFAILURE,
    SIGNUP,
    PAUSE,
}

public class PopUpManager : MonoBehaviour
{
    private static PopUpManager instance;
    public static PopUpManager Instance { get { return instance; } }

    private Dictionary<PopupType, GameObject> dictionary = new Dictionary<PopupType, GameObject>();

    [SerializeField] Transform parentTransform;

    private void Awake()
    {
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

        //tryGetValue�� key���� ã�´�
        if (dictionary.TryGetValue(popupType, out popup))
        {
            //�ִٸ� ���� ������Ʈ�� true
            popup.gameObject.SetActive(true);
        }
        else
        {
            //���ٸ� ���� ������Ʈ ����
            popup = Instantiate(Resources.Load<GameObject>("Sign In Failure PopUp"));
            // �θ� ��ġ ����
            popup.transform.SetParent(parentTransform);
            //PopUp������Ʈ�� ������ ���� SetData() �Լ� ȣ��
            popup.GetComponent<PopUp>().SetData(content);
            //Dictionary�� �߰�
            dictionary.Add(popupType, popup);
        }
    }
}
