using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    private static MouseManager instance;
    private static MouseManager Instance { get { return instance; } }

    private void OnEnable() //�� �̵��� ���� ó���� ���� �̺�Ʈ ���
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }


    public void SetMouse(bool state) 
    {
        Cursor.visible = state;
        Cursor.lockState = ((CursorLockMode)Convert.ToInt32(!state));
        //0 //Cursor.lockState = CursorLockMode.Locked;
        //1 //Cursor.lockState = CursorLockMode.None;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.buildIndex)
        {
            case 2:
                SetMouse(false);
                break;
            default:
                SetMouse(true);
                break;
        }
    }

    private void OnDisable() //�̺�Ʈ ����
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
