using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayCastHit;
    [SerializeField] Camera camera;

    void Update()
    {
        //버튼 클릭시 
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 위치 - 현재 마우스위치가 고정이라
            ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity))
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.05f);
                Debug.Log(rayCastHit.collider.gameObject.name);
            }
        }
    }
}
