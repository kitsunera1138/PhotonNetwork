using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Rifle : MonoBehaviourPunCallbacks
{
    private Ray ray;
    private RaycastHit rayCastHit;
    [SerializeField] Camera camera;
    [SerializeField] LayerMask layerMask;
    void Update()
    {
        //��ư Ŭ���� 
        if (Input.GetMouseButtonDown(0))
        {
            //���콺 ��ġ - ���� ���콺��ġ�� �����̶�
            ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity, layerMask))
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.05f);
                //Debug.Log(rayCastHit.collider.gameObject.name);
                PhotonView photonView = rayCastHit.collider.GetComponent<PhotonView>();

                if (photonView.IsMine)
                {
                    //Debug.Log("Shot");
                    //GameObject obj = photonview.gameObject;
                    //obj.GetComponent<Rake>().Die();
                    //Rake rake = photonView.gameObject.GetComponent<Rake>();
                    //rake.Release();
                    photonView.GetComponent<Rake>().Die();
                }

                /*
                if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity))
                {
                    if (rayCastHit.collider.gameObject.layer == LayerMask.NameToLayer("Rake"))
                    {
                        GameObject obj = rayCastHit.collider.gameObject;
                        //SendMessage�� �Ⱦ��°��� ���� .. ������ ������
                        //���������� C#�� ���÷���(reflection)�̶�� ��ɿ� �����Ѵ�. ���ڿ��� �̿��� �Լ��� �θ���, ���ø����̼��� ���� �߿� �����θ� ���캸�� ������ �ڵ带 ã�´�. �̷� ������ �Ϲ����� ������� �Լ��� ������ ������ ���ſ� ������ �ʿ�� �Ѵ�. �׷��� ������ SendMessage�� BroadcastMessage�� ����� �ּ�ȭ�ϵ��� �Ѵ�.
                        obj.SendMessage("Die");
                    }
                }
                */
            }
        }
    }

}
