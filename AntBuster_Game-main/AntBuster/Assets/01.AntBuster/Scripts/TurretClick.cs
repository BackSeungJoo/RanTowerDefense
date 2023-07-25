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
        // 특정 이름을 가진 자식 오브젝트를 가져옵니다.
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
