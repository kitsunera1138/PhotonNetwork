using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed = 300;

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void RotateX()
    {
        //mouseY 마우스로 입력한 값을 저장합니다. "Mouse Y"
        mouseY += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        //MouseY의 값을 -65~ 65 사이의 값으로 제한합니다.
        //mouseY <- Math.Clamp(제한하려는 값, 최소값, 최대값)
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        //카메라가 자식으로 들어가 있기때문에 local
        //localEulerAngles 의 경우 vector3로 회전 가능
        //오일러회전에서는 짐벌락 현상이 발생하므로  Quternian(쿼터니언) 회전을 사용하거나 제한된 범위에서 회전으로 설계해야 한다.
        transform.localEulerAngles = new Vector3(-mouseY,0, 0);
    }

}
