using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed = 300;

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void OnKeyUpdate()
    {
        //mouseX ���콺�� �Է��� ���� �����մϴ�. 
        mouseX += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidbody)
    {
        rigidbody.transform.localEulerAngles = new Vector3(0, mouseX, 0);
        //ĳ���� �ʿ��� rotation�ϱ� ������ world�� �ص���
    }

    public void RotateX()
    {
        //mouseY ���콺�� �Է��� ���� �����մϴ�. "Mouse Y"
        mouseY += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        //MouseY�� ���� -65~ 65 ������ ������ �����մϴ�.
        //mouseY <- Math.Clamp(�����Ϸ��� ��, �ּҰ�, �ִ밪)
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        //ī�޶� �ڽ����� �� �ֱ⶧���� local
        //localEulerAngles �� ��� vector3�� ȸ�� ����
        //���Ϸ�ȸ�������� ������ ������ �߻��ϹǷ�  Quternian(���ʹϾ�) ȸ���� ����ϰų� ���ѵ� �������� ȸ������ �����ؾ� �Ѵ�.
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }

}
