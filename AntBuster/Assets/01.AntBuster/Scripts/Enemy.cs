using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float MaxHealth = 20f;         // ���� �ִ� ü��
    public float CurrentHealth = 20f;     // ���� ü��

    public GameObject DamageText;   // �ǰ� ������ �� �ؽ�Ʈ
    public GameObject TextPos;      // �ؽ�Ʈ ��ġ

    public GameObject HealthBar;    // ü�� ��

    private void Update()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1�� �Ѿ˿� �¾Ҵ�.
        if (other.tag.Equals("Bullet_1"))
        {
            Debug.Log("Ʈ���� �¾Ҵ�!");
            GetDamage(GameManager.instance.Turret01_Damage);

            // ü���� 0�� �Ǹ� �ı�
            if (CurrentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        // ����ο� �����ߴ�.
        if (other.tag.Equals("EndLine"))
        {
            // ����� 1�� �Ұ�

            // �ı��Ѵ�.
            Destroy(gameObject);
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
