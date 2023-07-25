using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color StartColor;
    public Color SelectColor;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    private void Update()
    {
        if (GameManager.instance.SelectNode == this.gameObject)
        {
            rend.material.color = SelectColor;
        }
        else
        {
            rend.material.color = StartColor;
        }
    }

    private void OnMouseDown()
    {
        rend.material.color = SelectColor;
    }

    private void OnMouseUp()
    {
        if (transform.childCount == 0)
        {
            GameManager.instance.SelectNode = this.gameObject;
        }
        else { return; }
    }
}
