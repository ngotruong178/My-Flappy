using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject yellowBird;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public GameObject GameOver;
    [SerializeField] public GameObject GameStart;
    [SerializeField] public GameObject GamePause;
    [SerializeField] public GameObject PauseButton;
    [SerializeField] public Transform StartPos;
    public bool isStarted = false;
    public int score;
    private void Awake()
    {
        
    }
    void Start()
    {
        score = 0;
        if(Select.bird == null)
        {
            Select.bird = yellowBird; 
        }
        GameOver.SetActive(false);
        GameStart.SetActive(true);
        GamePause.SetActive(false);
        PauseButton.SetActive(false);
        Instantiate(Select.bird,StartPos.position, Quaternion.identity);
        
    }


    void Update()
    {
        
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Pause()
    {
        Time.timeScale = 0;
        GamePause.SetActive(true);
        PauseButton.SetActive(false);
    }
    public void Restart()
    {
        score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GamePause.SetActive(false);
        PauseButton.SetActive(true);
    }
    

}
