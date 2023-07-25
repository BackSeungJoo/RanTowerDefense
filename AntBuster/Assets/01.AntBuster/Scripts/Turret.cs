using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameData gameData;
    public GameObject bulletPrefab = default;   // �Ѿ� ������
    public float attackSpeed = 2f;              // �ͷ��� ���ݼӵ�

    public float attackEnd = default;           // ������ ��
    private GameObject bullet = default;        // ������ �Ѿ�
    // private Transform target = default;      // ������ ��
    private bool isShot = default;              // �������� �� �߰��� ���� ���ϰ�
        

    // Start is called before the first frame update
    void Start()
    {
        attackEnd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackEnd += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        // �巡�� ���� �� return
        if(gameData.isDragging) { return; }

        // �巡������ �ƴ� �� ���� ����
        else
        {
            // ���� Ʈ���žȿ� �ִ�.
            if (other.tag.Equals("Enemy"))
            {
                // Ÿ���� ��ġ���� �����´�.
                Vector3 targetPosition = other.transform.position;

                //// Ÿ���� �ٶ󺻴�.
                //transform.LookAt(targetPosition);

                // y���� ���� �ڽ��� y�� ������ ������ŵ�ϴ�.
                targetPosition.y = transform.position.y;

                // ���ݼӵ� ��Ÿ���� á���� �Ǵ�
                if (attackEnd <= attackSpeed)
                {
                    isShot = false;
                }

                // ���ݼӵ� ��Ÿ���� ������ �Ѿ� �߻�.
                if (attackEnd >= attackSpeed && isShot == false)
                {
                    isShot = true;
                    transform.LookAt(targetPosition);
                    attackEnd = 0;

                    // �Ѿ� ����
                    bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                    // �Ѿ��� �ٶ󺻴�.
                    transform.LookAt(bullet.transform);

                    // �Ѿ��� ���� �� �� ��ġ �� ����
                    Vector3 bulletPosition = bullet.transform.position;
                    //bulletPosition.y += 0.7f;
                    //bulletPosition.z += 0.77f;
                    bullet.transform.position = bulletPosition;
                }
            }
        }
    }
}
