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
        //��ư Ŭ���� 
        if (Input.GetMouseButtonDown(0))
        {
            //���콺 ��ġ - ���� ���콺��ġ�� �����̶�
            ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity))
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.05f);
                Debug.Log(rayCastHit.collider.gameObject.name);
            }
        }
    }
}
