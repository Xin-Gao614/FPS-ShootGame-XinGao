using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UIController: MonoBehaviour
{
    [SerializeField] public Slider hpSlider;
    [SerializeField] public TextMeshProUGUI ammoAmount;

    [SerializeField] public GameObject gameOverPanel;


    public void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void UpdateHP(float value)
    {
        hpSlider.value = value;
    }

    public void UpdateAmmo(int value)
    {
        ammoAmount.text = value.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
