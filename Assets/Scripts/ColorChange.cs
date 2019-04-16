using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Renderer m_Renderer;
    Color lerpedColor = Color.green;
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(Color.green, Color.yellow, Mathf.PingPong(Time.time, 1));
        m_Renderer.material.color = lerpedColor;
    }
}
