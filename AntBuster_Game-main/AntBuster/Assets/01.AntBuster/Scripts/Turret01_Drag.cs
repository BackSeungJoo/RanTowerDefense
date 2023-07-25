using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret01_Drag : MonoBehaviour
{
    public bool draggable;              // �巡�װ� ������ �������� Ȯ���ϴ� bool ����
    public CreateTurret01 createTurret01; // Turret01_Drag�� �����ϱ� ���� ����
    private Transform attackRange;      // ���� ���� ǥ���ϴ� ���ӿ�����Ʈ

    private void Awake()
    {
        // Ư�� �̸��� ���� �ڽ� ������Ʈ�� �����ɴϴ�.
        attackRange = transform.Find("Turret_Lv1/Attack_Range");
    }

    // �� ������ �� ȣ��Ǵ� �޼ҵ�
    void Update()
    {
        // ����ڰ� ���콺 ���ʹ�ư�� ������ �� true�� ��ȯ�� if�� �� �ڵ� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���� ���� ǥ��
            attackRange.gameObject.SetActive(true);

            // Raycast�� ������ �ε��� ������Ʈ ��ȯ
            RaycastHit hit = CastRay();

            // �ε��� ������Ʈ�� ���� ��ũ��Ʈ update�޼ҵ尡 ����ǰ� �ִ� ������Ʈ�� ���
            if (hit.transform == transform)
            {
                // �巡�װ� ������ ���·� ����
                draggable = true;
            }
        }

        // ����ڰ� ���콺 ���ʹ�ư�� ���� ���¿��� �հ����� ������ �� true�� ��ȯ�� if�� �� �ڵ� ����
        if (Input.GetMouseButtonUp(0))
        {
            // ���� ���� ǥ�� �ʱ�ȭ
            attackRange.gameObject.SetActive(false);

            // �巡�װ� �Ұ����� ���·� ����
            draggable = false;

            // ���� ������ createTurret01 ��ũ��Ʈ�� �ִٸ� if �� �� �ڵ� ����
            if(createTurret01 != null)
            {
                // �ش� ��ũ��Ʈ �� turret01 null ó��
                createTurret01.turret01 = null;

                // �ش� ��ũ��Ʈ ���� ����
                createTurret01 = null;
            }
        }

        // ���� �巡�װ� ������ ������ ��� if�� �� �ڵ� ����
        if (draggable)
        {
            // ���� ���� ǥ��
            attackRange.gameObject.SetActive(true);

            // ���� ȭ�鿡 �ִ� ���콺 Ŀ���� x,y ��ǥ�� ī�޶� ���� ���� �� ��ũ��Ʈ�� ����Ǵ� ������Ʈ�� z��ǥ�� ����� ScreenPoint Vector3 position �� ����
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            // ������Ʈ�� �̵��� �� ������ x,z ��ǥ�� ���� WorldPoint Vector3 position ����
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            // �� worldPosition�� x,z ��ǥ�� ����ϰ� ���� y��ǥ�� ������ ������Ʈ �̵�
            transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
        }
    }

    // Raycast�� �浹�� ������ ��ȯ�ϴ� �޼ҵ�
    private RaycastHit CastRay()
    {
        // ���콺 Ŀ���� ����Ű�� ī�޶� �������ϴ� ���� �հ��� ��ġ ScreenPoint Vector3 position
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        // ���콺 Ŀ���� ����Ű�� ī�޶� �������ϴ� ���� �������� ��ġ ScreenPoint Vector3 position
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        // �� ��ġ�� WorldPosition���� ����
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        // RaycastHit ������ ���� ���� ����
        RaycastHit hit;
        // ���� worldMousePosNear���� �����ϰ� worldMousePosFar�� ���ϴ� Raycast�� �����Ѵ�
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        // ������ ���� hit ��ȯ
        return hit;
    }
}