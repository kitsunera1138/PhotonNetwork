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

    private void OnEnable() //씬 이동에 따른 처리에 대한 이벤트 등록
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

    private void OnDisable() //이벤트 해제
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
