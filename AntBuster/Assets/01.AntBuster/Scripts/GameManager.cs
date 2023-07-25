using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글턴 인스턴스를 저장할 정적 변수
    public static GameManager instance;

    // 게임 오브젝트들
    public GameObject SelectNode;   // 선택한 노드
    public GameObject Tower;        // 생성할 타워

    // 게임 변수들
    public int Turret01_Damage = 10;

    // GamaManager 싱글턴 인스턴스에 접근할 수 있는 프로퍼티
    public static GameManager Instance
    {
        get { return instance; }
    }

    // 게임 관련 변수들
    public GameObject endLine;

    private void Awake()
    {
        // 인스턴스가 이미 존재하는 경우 중복 생성을 방지하기 위해
        // 게임 오브젝트를 파괴합니다.
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        // 싱글턴 인스턴스를 현재 인스턴스로 설정합니다.
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildToTower()
    {
        Instantiate(Tower, SelectNode.transform.position, Quaternion.identity);
    }
}
