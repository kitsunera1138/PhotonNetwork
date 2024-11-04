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
        //버튼 클릭시 
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 위치 - 현재 마우스위치가 고정이라
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
                        //SendMessage는 안쓰는것이 좋음 .. 느리기 때문에
                        //내부적으로 C#의 리플렉션(reflection)이라는 기능에 의존한다. 문자열을 이용해 함수를 부르면, 애플리케이션은 실행 중에 스스로를 살펴보고 실행할 코드를 찾는다. 이런 과정은 일반적인 방법으로 함수를 실행할 때보다 무거운 연산을 필요로 한다. 그렇기 때문에 SendMessage와 BroadcastMessage의 사용을 최소화하도록 한다.
                        obj.SendMessage("Die");
                    }
                }
                */
            }
        }
    }

}
