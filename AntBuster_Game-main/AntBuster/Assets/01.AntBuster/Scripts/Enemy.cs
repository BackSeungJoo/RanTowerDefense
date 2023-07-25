using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float MaxHealth = 20f;           // 적의 최대 체력
    public float CurrentHealth = 20f;       // 현재 체력

    public GameObject DamageText;           // 피격 당했을 때 텍스트
    public GameObject TextPos;              // 텍스트 위치

    public GameObject HealthBar;            // 체력 바
    public int enemyKillMoney = 10;         // 적을 잡았을 때 획득하는 돈

    private void Awake()
    {
        // 레벨에 따른 몬스터 체력 조정
        MaxHealth = 20f + (GameManager.instance.level * 5);
        CurrentHealth = 20f + (GameManager.instance.level * 5);
    }

    private void Update()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1번 총알에 맞았다.
        if (other.tag.Equals("Bullet_1"))
        {
            Debug.Log("트리거 맞았다!");
            GetDamage(GameManager.instance.Turret01_Damage);

            // 체력이 0이 되면 파괴
            if (CurrentHealth <= 0)
            {
                Destroy(this.gameObject);
                GameManager.instance.playerMoney += enemyKillMoney;
                GameManager.instance.killEnemy++;

                // 레벨 업 조건
                if (GameManager.instance.killEnemy % 5 == 0)
                {
                    GameManager.instance.level++;
                }
            }
        }

        // 골라인에 도착했다.
        if (other.tag.Equals("EndLine"))
        {
            // 목숨을 1개 잃고
            GameManager.instance.playerLife--;
            GameManager.instance.heart[GameManager.instance.playerLife].enabled = false;
            GameManager.instance.heart.RemoveAt(GameManager.instance.playerLife);

            // 파괴한다.
            Destroy(gameObject);

            // 게임 엔드
            if(GameManager.instance.playerLife <= 0)
            {
                GameManager.instance.gameEndUI.SetActive(true);
            }
        }
    }

    public void GetDamage(int damage)
    {
        GameObject dmgText = Instantiate(DamageText, TextPos.transform.position, Quaternion.Euler(90,0,0));
        dmgText.GetComponent<Text>().text = damage.ToString();

        CurrentHealth -= damage;
        HealthBar.GetComponent<Image>().fillAmount = CurrentHealth / MaxHealth;

        Destroy(dmgText, 0.5f);
    }
}
