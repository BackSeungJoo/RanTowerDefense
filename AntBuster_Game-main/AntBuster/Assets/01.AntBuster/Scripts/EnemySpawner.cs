using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;

    public float spawnWait = 0.5f;
    public float spawnedTime = 0;
    public int enemyCount = 0;

    public bool isGaming = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if : ������ ���� �Ǹ� �� ����
        if (isGaming)
        {
            // �����ð� ���� ���ʹ� ����
            spawnedTime += Time.deltaTime;

            // ���� �ð��� ������, Ư�� ������ �������� �ʾҴٸ�
            if (spawnedTime > spawnWait && enemyCount <= 100)
            {
                Debug.Log("������");
                GameObject newEnemy = Instantiate(enemyPrefabs, this.gameObject.transform.position, gameObject.transform.rotation);
                enemyCount++;
                spawnedTime = 0;
            }
        }
    }
}
