using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameData gameData;
    public GameObject bulletPrefab = default;   // 총알 프리팹
    public float attackSpeed = 2f;              // 터렛의 공격속도

    public float attackEnd = default;           // 공격한 후
    private GameObject bullet = default;        // 생성할 총알
    // private Transform target = default;      // 공격할 적
    private bool isShot = default;              // 공격했을 때 추가로 공격 못하게
        

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
        // 드래그 중일 때 return
        if(gameData.isDragging) { return; }

        // 드래그중이 아닐 때 로직 실행
        else
        {
            // 적이 트리거안에 있다.
            if (other.tag.Equals("Enemy"))
            {
                // 타겟의 위치값을 가져온다.
                Vector3 targetPosition = other.transform.position;

                //// 타겟을 바라본다.
                //transform.LookAt(targetPosition);

                // y축을 현재 자신의 y축 값으로 고정시킵니다.
                targetPosition.y = transform.position.y;

                // 공격속도 쿨타임을 찼음을 판단
                if (attackEnd <= attackSpeed)
                {
                    isShot = false;
                }

                // 공격속도 쿨타임이 됬으면 총알 발사.
                if (attackEnd >= attackSpeed && isShot == false)
                {
                    isShot = true;
                    transform.LookAt(targetPosition);
                    attackEnd = 0;

                    // 총알 생성
                    bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                    // 총알을 바라본다.
                    transform.LookAt(bullet.transform);

                    // 총알이 생성 될 때 위치 값 수정
                    Vector3 bulletPosition = bullet.transform.position;
                    //bulletPosition.y += 0.7f;
                    //bulletPosition.z += 0.77f;
                    bullet.transform.position = bulletPosition;
                }
            }
        }
    }
}
