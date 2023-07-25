using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateTurret01 : MonoBehaviour
{
    // ������ cube Prefabs
    public GameObject turretToCreate;

    // ������ Prefab�� ������ ����
    public GameObject turret01;

    // Prefab ���� �޼ҵ�
    public void DragTurret01()
    {
        // ���� �����Ǿ� �巡�� ���� Prefab�� ���� ��� if �� �ڵ� ����
        if(turret01 == null)
        {
            // ���� ȭ�鿡 �ִ� ���콺 Ŀ���� x,y ��ǥ�� ī�޶� ����
            // ���� �� ��ũ��Ʈ�� ����Ǵ� ������Ʈ�� z��ǥ�� �̿���
            // ScreenPoint Vector3 position �� ����
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);

            // ������Ʈ�� �̵��� �� ������ x,z ��ǥ�� ���� WorldPoint Vector3 position ����
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            // Prefab�� �����ϰ� turret01 ������ ����
            turret01 = Instantiate(turretToCreate, new Vector3(worldPosition.x, 1f, worldPosition.y), Quaternion.identity);

            // �� ��ũ��Ʈ�� ������ Prefab�� �����ϰ� ����
            turret01.GetComponent<Turret01_Drag>().createTurret01 = this;

            // �ش� ������Ʈ ��ũ��Ʈ�� draggable ������ true�� ������ ���콺�� ���� ������ �� �ְ� �����.
            turret01.GetComponent<Turret01_Drag>().draggable = true;
        }
    }
}
