using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateTurret01 : MonoBehaviour
{
    // 생성할 cube Prefabs
    public GameObject turretToCreate;

    // 생성한 Prefab을 저장할 변수
    public GameObject turret01;

    // Prefab 생성 메소드
    public void DragTurret01()
    {
        // 현재 생성되어 드래그 중인 Prefab이 없을 경우 if 내 코드 실행
        if(turret01 == null)
        {
            // 현재 화면에 있는 마우스 커서의 x,y 좌표와 카메라를 통해
            // 보는 이 스크립트가 실행되는 오브젝트의 z좌표를 이용해
            // ScreenPoint Vector3 position 값 생성
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);

            // 오브젝트를 이동할 때 움직일 x,z 좌표를 가진 WorldPoint Vector3 position 생성
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            // Prefab을 생성하고 turret01 변수에 저장
            turret01 = Instantiate(turretToCreate, new Vector3(worldPosition.x, 1f, worldPosition.y), Quaternion.identity);

            // 이 스크립트를 생성된 Prefab이 참조하게 변경
            turret01.GetComponent<Turret01_Drag>().createTurret01 = this;

            // 해당 오브젝트 스크립트의 draggable 변수를 true로 변경해 마우스를 따라 움직일 수 있게 만든다.
            turret01.GetComponent<Turret01_Drag>().draggable = true;
        }
    }
}
