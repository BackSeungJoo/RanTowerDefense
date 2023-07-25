using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret01_Drag : MonoBehaviour
{
    public bool draggable;              // 드래그가 가능한 상태인지 확인하는 bool 변수
    public CreateTurret01 createTurret01; // Turret01_Drag을 참조하기 위한 변수
    private Transform attackRange;      // 공격 범우 표시하는 게임오브젝트

    private void Awake()
    {
        // 특정 이름을 가진 자식 오브젝트를 가져옵니다.
        attackRange = transform.Find("Turret_Lv1/Attack_Range");
    }

    // 매 프레임 별 호출되는 메소드
    void Update()
    {
        // 사용자가 마우스 왼쪽버튼을 눌렀을 때 true를 반환해 if문 내 코드 실행
        if (Input.GetMouseButtonDown(0))
        {
            // 공격 범위 표시
            attackRange.gameObject.SetActive(true);

            // Raycast를 생성해 부딪힌 오브젝트 반환
            RaycastHit hit = CastRay();

            // 부딪힌 오브젝트가 현재 스크립트 update메소드가 실행되고 있는 오브젝트일 경우
            if (hit.transform == transform)
            {
                // 드래그가 가능한 상태로 변경
                draggable = true;
            }
        }

        // 사용자가 마우스 왼쪽버튼을 누른 상태에서 손가락을 떼었을 때 true를 반환해 if문 내 코드 실행
        if (Input.GetMouseButtonUp(0))
        {
            // 공격 범위 표시 초기화
            attackRange.gameObject.SetActive(false);

            // 드래그가 불가능한 상태로 변경
            draggable = false;

            // 현재 참조된 createTurret01 스크립트가 있다면 if 문 내 코드 실행
            if(createTurret01 != null)
            {
                // 해당 스크립트 내 turret01 null 처리
                createTurret01.turret01 = null;

                // 해당 스크립트 참조 해제
                createTurret01 = null;
            }
        }

        // 현재 드래그가 가능한 상태일 경우 if문 내 코드 실행
        if (draggable)
        {
            // 공격 범위 표시
            attackRange.gameObject.SetActive(true);

            // 현재 화면에 있는 마우스 커서의 x,y 좌표와 카메라를 통해 보는 이 스크립트가 실행되는 오브젝트의 z좌표를 사용해 ScreenPoint Vector3 position 값 생성
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            // 오브젝트를 이동할 때 움직일 x,z 좌표를 가진 WorldPoint Vector3 position 생성
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            // 위 worldPosition의 x,z 좌표를 사용하고 직접 y좌표를 설정해 오브젝트 이동
            transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
        }
    }

    // Raycast에 충돌한 정보를 반환하는 메소드
    private RaycastHit CastRay()
    {
        // 마우스 커서가 가리키는 카메라가 랜더링하는 가장 먼곳의 위치 ScreenPoint Vector3 position
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        // 마우스 커서가 가리키는 카메라가 랜더링하는 가장 가까운곳의 위치 ScreenPoint Vector3 position
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        // 각 위치를 WorldPosition으로 변경
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        // RaycastHit 정보를 담을 변수 생성
        RaycastHit hit;
        // 현재 worldMousePosNear에서 시작하고 worldMousePosFar로 향하는 Raycast를 생성한다
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        // 정보를 가진 hit 반환
        return hit;
    }
}