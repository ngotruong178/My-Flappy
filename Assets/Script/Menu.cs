using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public int maxScore;

    private void Awake()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }
    void Start()
    {
        
        highScore.text = "Highest Score: " + maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Change()
    {
        SceneManager.LoadScene("Change");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
}
