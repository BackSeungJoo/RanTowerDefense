using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private void Update()
    {
        // 마우스 왼쪽 버튼을 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 클릭했음.");

            // 스크린 좌표계에서 마우스의 현재 좌표를 관통하는 ray를 생성한다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);      // Raycast로 얻어낸 ray를 쏘면 충돌하는 물체를 얻어낼 수 있다.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    ////! 스크린 좌표를 기준으로 ray를 쏴서 오브젝트와 충돌시켜보겠다.
    ////  어떤 스크린 좌표계의 좌표를 글로벌 스페이스의 ray로 바꾸기 위해 ScreenPointToRay 메서드를 사용할 수 있다.

    //// 마우스를 왼쪽 클릭했을 때 raycast하는 코드
    //private void OnMouseDown()
    //{
    //        Debug.Log("마우스 클릭했음.");

    //        // 스크린 좌표계에서 마우스의 현재 좌표를 관통하는 ray를 생성한다.
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);      // Raycast로 얻어낸 ray를 쏘면 충돌하는 물체를 얻어낼 수 있다.
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            Debug.Log(hit.transform.name);
    //        }
    //}
}
