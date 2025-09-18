using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public static GameObject bird = null;
    [SerializeField] private GameObject yellowBird;
    [SerializeField] private GameObject Naruto;
    [SerializeField] private GameObject Goku;
    public Button yellowButton;
    public Button NarutoButton;
    public Button GokuButton;
    public TextMeshProUGUI GokuText;
    public TextMeshProUGUI NarutoText;
    public float GokuScore = 50;
    public float NarutoScore = 20;
    public int maxScore;
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (maxScore >= NarutoScore)
        {
            NarutoButton.interactable = true;
            NarutoText.gameObject.SetActive(false);
        }
        else
        {
            NarutoButton.interactable = false;
            NarutoText.text = "Max Score >= " + NarutoScore;
            NarutoText.gameObject.SetActive(true);
        }
        if (maxScore >= GokuScore)
        {
            GokuButton.interactable = true;
            GokuText.gameObject.SetActive(false);
        }
        else
        {
            GokuButton.interactable = false;
            GokuText.text = "Max Score >= " + GokuScore;
            GokuText.gameObject.SetActive(true);
        }
    }
    public void SetYellowBird()
    {
        bird = yellowBird;
    }
    public void SetGoku()
    {
        bird = Goku;
    }
    public void SetNaruto()
    {
        bird = Naruto;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
