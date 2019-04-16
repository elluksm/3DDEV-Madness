using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    Renderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        StartCoroutine("GetRandomColor");
    }

    void Update()
    {
        
    }

    IEnumerator GetRandomColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            m_Renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
