using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ��� ������ ���� ����
    public static GameManager instance;

    // ���� ������Ʈ��
    public GameObject SelectNode;   // ������ ���
    public GameObject Tower;        // ������ Ÿ��
    public GameObject turretInfo;   // �ͷ� ����
    public GameObject gameEndUI;      // ���� ���� UI

    public Text moneyText;          // �÷��̾� ������ text
    public Text levelText;          // �÷��̾� ������ text

    public List<Image> heart;       // ��� �̹��� ����Ʈ

    // ���� ������
    public int Turret01_Damage = 10;    // Ÿ�� 1 ������
    public int Turret01_Cost = 100;     // Ÿ�� 1 ���

    public int playerMoney = 300;       // �÷��̾� ������
    public int playerLife = 8;          // �÷��̾� ���

    public int level = 1;               // ���� ����
    public int killEnemy = 0;           // �� ������ ���� ��Ҵ°�?

    // GamaManager �̱��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ
    public static GameManager Instance
    {
        get { return instance; }
    }

    // ���� ���� ������
    public GameObject endLine;

    private void Awake()
    {
        // �ν��Ͻ��� �̹� �����ϴ� ��� �ߺ� ������ �����ϱ� ����
        // ���� ������Ʈ�� �ı��մϴ�.
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        // �̱��� �ν��Ͻ��� ���� �ν��Ͻ��� �����մϴ�.
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // text ���
        levelText.text = string.Format("Level {0}", level);
        moneyText.text = string.Format("{0}��", playerMoney);

        // ���� �����
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
