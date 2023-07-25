using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ��� ������ ���� ����
    public static GameManager instance;

    // ���� ������Ʈ��
    public GameObject SelectNode;   // ������ ���
    public GameObject Tower;        // ������ Ÿ��

    // ���� ������
    public int Turret01_Damage = 10;

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
        
    }

    public void BuildToTower()
    {
        Instantiate(Tower, SelectNode.transform.position, Quaternion.identity);
    }
}
