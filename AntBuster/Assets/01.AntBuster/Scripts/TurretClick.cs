using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretClick : MonoBehaviour
{
    public Transform attackRange;

    // Start is called before the first frame update
    void Start()
    {
        // Ư�� �̸��� ���� �ڽ� ������Ʈ�� �����ɴϴ�.
        attackRange = transform.Find("Turret_Lv1/Attack_Range");
    }

    private void OnMouseDown()
    {
        attackRange.gameObject.SetActive(true);
    }

    private void OnMouseUp()
    {
        attackRange.gameObject.SetActive(false);
    }



}
