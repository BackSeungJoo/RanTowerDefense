using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글턴 인스턴스를 저장할 정적 변수
    public static GameManager instance;

    // 게임 오브젝트들
    public GameObject SelectNode;   // 선택한 노드
    public GameObject Tower;        // 생성할 타워
    public GameObject turretInfo;   // 터렛 정보
    public GameObject gameEndUI;      // 게임 엔드 UI

    public Text moneyText;          // 플레이어 소지금 text
    public Text levelText;          // 플레이어 소지금 text

    public List<Image> heart;       // 목숨 이미지 리스트

    // 게임 변수들
    public int Turret01_Damage = 10;    // 타워 1 데미지
    public int Turret01_Cost = 100;     // 타워 1 비용

    public int playerMoney = 300;       // 플레이어 소지금
    public int playerLife = 8;          // 플레이어 목숨

    public int level = 1;               // 현재 레벨
    public int killEnemy = 0;           // 몇 마리의 적을 잡았는가?

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
        // text 출력
        levelText.text = string.Format("Level {0}", level);
        moneyText.text = string.Format("{0}원", playerMoney);

        // 게임 재시작
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

    public void BuildToTower()
    {
        if (playerMoney >= Turret01_Cost && SelectNode != null)
        {
            playerMoney -= Turret01_Cost;
            GameObject newTower = Instantiate(Tower, SelectNode.transform.position, Quaternion.identity);
            newTower.transform.parent = SelectNode.transform;
            SelectNode = null;
        }
        else { return; }
    }

    public void ExitTurretInfo()
    {
        turretInfo.gameObject.SetActive(false);
    }
}
