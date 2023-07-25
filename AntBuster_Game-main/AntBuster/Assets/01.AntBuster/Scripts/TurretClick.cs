using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretClick : MonoBehaviour
{
    public Transform attackRange;
    public bool selected = default;

    // Start is called before the first frame update
    void Start()
    {
        // Ư�� �̸��� ���� �ڽ� ������Ʈ�� �����ɴϴ�.
        attackRange = transform.Find("Turret_Lv1/Attack_Range");
    }

    private void OnMouseDown()
    {
        if (selected == false)
        {
            attackRange.gameObject.SetActive(true);
            selected = true;
        }
        else
        {
            attackRange.gameObject.SetActive(false);
            selected = false;
        }
    }

    private void OnMouseUp()
    {
        GameManager.instance.turretInfo.gameObject.SetActive(true);
    }



}
