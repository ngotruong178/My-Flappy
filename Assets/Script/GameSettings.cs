using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField jumpForceInput;
    [SerializeField] private TMP_InputField pipeSpeedInput;
    [SerializeField] private TextMeshProUGUI jumpNow;
    [SerializeField] private TextMeshProUGUI pipeNow;
    private float jumpForce;
    private float pipeSpeed;
    private Bird bird;
    private Pipe pipe;
    void Start()
    {
        
        bird = FindAnyObjectByType<Bird>();
        pipe = FindAnyObjectByType<Pipe>();
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpForce = PlayerPrefs.GetFloat("NewJump", 5f);
        pipeSpeed = PlayerPrefs.GetFloat("NewPipe", 3f);
        jumpNow.text = "Lực nhảy hiện tại: " + jumpForce;
        pipeNow.text = "Tốc độ ống nước hiện tại: " + pipeSpeed;
    }
    public void ApplySettings()
    {
        string jumpInput = jumpForceInput.text.Trim();
        string pipeInput = pipeSpeedInput.text.Trim();
        jumpInput = jumpInput.Replace(',', '.');
        pipeInput = pipeInput.Replace(',', '.');
        if (float.TryParse(jumpInput, out float newJump))
        {
            newJump = Mathf.Clamp(newJump, 0f, 50f);
            PlayerPrefs.SetFloat("NewJump",newJump);
            PlayerPrefs.Save();
        }
        if (float.TryParse(pipeInput, out float newPipe)) 
        {
            newPipe = Mathf.Clamp(newPipe, 0f, 50f);
            PlayerPrefs.SetFloat("NewPipe",newPipe);
            PlayerPrefs.Save();
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
