using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private int scoreplus = 1;
    private int maxScore;
    [SerializeField] public float jumpForce;
    private GameManager gameManager;
    
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        rb = GetComponent<Rigidbody2D>();
        jumpForce = PlayerPrefs.GetFloat("NewJump", 5f);
        gameManager = FindAnyObjectByType<GameManager>();
        Time.timeScale = 0;
    }
    void Update()
    {
        if (!gameManager.isStarted && Input.GetMouseButtonDown(0)) 
        {
            gameManager.isStarted = true;
            gameManager.GameStart.SetActive(false);
            gameManager.PauseButton.SetActive(true);
            Time.timeScale = 1;
        }
        Fly();
    }
    public void Fly()
    {
        if (Input.GetMouseButtonDown(0) && gameManager.isStarted && !IsPointerOverUI())
        {
            rb.linearVelocity = new Vector2(0,jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            gameManager.score += scoreplus;
            gameManager.scoreText.text = gameManager.score.ToString();
        }
        if (other.CompareTag("Trap"))
        {
            gameManager.GameOver.SetActive(true);
            gameManager.PauseButton.SetActive(false);
            Time.timeScale = 0;
            if (gameManager.score > maxScore)
            {
                PlayerPrefs.SetInt("MaxScore",gameManager.score);
                PlayerPrefs.Save();
            }
        }
    }
    
    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
