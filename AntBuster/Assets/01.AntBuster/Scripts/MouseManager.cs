using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("���콺 Ŭ������.");

            // ��ũ�� ��ǥ�迡�� ���콺�� ���� ��ǥ�� �����ϴ� ray�� �����Ѵ�.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);      // Raycast�� �� ray�� ��� �浹�ϴ� ��ü�� �� �� �ִ�.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    ////! ��ũ�� ��ǥ�� �������� ray�� ���� ������Ʈ�� �浹���Ѻ��ڴ�.
    ////  � ��ũ�� ��ǥ���� ��ǥ�� �۷ι� �����̽��� ray�� �ٲٱ� ���� ScreenPointToRay �޼��带 ����� �� �ִ�.

    //// ���콺�� ���� Ŭ������ �� raycast�ϴ� �ڵ�
    //private void OnMouseDown()
    //{
    //        Debug.Log("���콺 Ŭ������.");

    //        // ��ũ�� ��ǥ�迡�� ���콺�� ���� ��ǥ�� �����ϴ� ray�� �����Ѵ�.
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);      // Raycast�� �� ray�� ��� �浹�ϴ� ��ü�� �� �� �ִ�.
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            Debug.Log(hit.transform.name);
    //        }
    //}
}
