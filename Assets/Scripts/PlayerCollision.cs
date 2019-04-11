using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody rb;
    public Text lifeCountText;
    public Text statusText;
    public Text timeText;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 3;
        SetCountText();
        statusText.text = "";
        timeText.text = "35";
    }

    void OnCollisionEnter (Collision collisionInfo )
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            // Debug.Log(collisionInfo.collider.name);
            count = count - 1;
            SetCountText();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Life"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        lifeCountText.text = "Your health: " + count.ToString();
        if (count < 1)
        {
        statusText.text = "Game Over";
        }
    }
}