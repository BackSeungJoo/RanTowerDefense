using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveable : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent agent;
    Vector3 targetPos = default;

    private void Awake()
    {
       // ������ ���۵Ǹ� ���� ������Ʈ�� ������ NavMeshAgent ������Ʈ�� �����ͼ� ����
       agent = GetComponent<NavMeshAgent>();

       // �������� ��ġ�� ������
       targetPos = GameManager.Instance.endLine.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ������Ʈ���� �������� �˷��ִ� �Լ�
        agent.SetDestination(targetPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������� �����ϸ� �ı�
        if (other.tag == "EndLine")
        {
            Destroy(gameObject);
        }
    }
}
