using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveable : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent agent;
    Vector3 targetPos = default;

    private void Awake()
    {
       // 게임이 시작되면 게임 오브젝트에 부착된 NavMeshAgent 컴포넌트를 가져와서 저장
       agent = GetComponent<NavMeshAgent>();

       // 목적지의 위치를 가져옴
       targetPos = GameManager.Instance.endLine.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 에이전트에게 목적지를 알려주는 함수
        agent.SetDestination(targetPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 목적지에 도착하면 파괴
        if (other.tag == "EndLine")
        {
            Destroy(gameObject);
        }
    }
}
