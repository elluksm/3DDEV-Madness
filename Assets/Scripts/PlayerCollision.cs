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
    private bool isGameFinished;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 3;
        SetCountText();
        statusText.text = "";
        timeText.text = "35";
        isGameFinished = false;
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

        if (other.gameObject.CompareTag("End"))
        {
            isGameFinished = true;
            statusText.text = "You win! You are safely at home..";
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

    void FixedUpdate()
    {
        if(rb.position.y < -1f && !isGameFinished)
        {
            statusText.text = "Game Over";
        }

    }
}