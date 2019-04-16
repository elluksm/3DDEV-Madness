using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody rb;
    public Text lifeCountText;
    public Text statusText;
    public Text timeText;
    public Text descriptionText;
    public Text gameRulesText;
    public Button startButton;
    public Button restartButton;
    private int count;
    private float timer;
    private bool isGameStarted;
    private bool isGameFinished;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 3;
        timer = 0.0f;
        SetCountText();
        statusText.text = "";
        timeText.text = "";
        isGameStarted = false;
        isGameFinished = false;
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        startButton.gameObject.SetActive(false);
        descriptionText.gameObject.SetActive(false);
        gameRulesText.gameObject.SetActive(false);

        //enable player movement script
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        isGameStarted = true;
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
            statusText.text = "You win!";
            EndGame();
        }
    }

    void FixedUpdate()
    {
        if(rb.position.y < -1f && !isGameFinished)
        {
            statusText.text = "Game Over";
            EndGame();
        }

        SetTimerText();
    }

    void SetCountText()
    {
        var ct = "";
        for(var i=0; i< count; i++)
        {
            ct = ct + "*";
        }
        lifeCountText.text = ct.ToString();
        if (count < 1)
        {
            statusText.text = "Game Over";
            EndGame();
        }
    }

    void SetTimerText()
    {
        if(isGameStarted)
        {
            timer += Time.deltaTime;
            timeText.text = timer.ToString("0.00");
        }
    }

    void EndGame()
    {
        isGameStarted = false;

        //disable player movement script
        gameObject.GetComponent<PlayerMovement>().enabled = false;

        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}