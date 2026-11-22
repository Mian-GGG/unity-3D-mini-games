using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControlAlienShooter : MonoBehaviour
{
    private int score = 0, alienCounter = 21;
    [SerializeField] GameObject _winScreen, _pauseScreen, _crosshair;
    [SerializeField] TextMeshProUGUI _score, _alienCounter;
    AudioSource _audioSourcebg;

    void Start()
    {
        _crosshair.SetActive(true);
        score = 0;
        alienCounter = 21;
        _audioSourcebg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ResumeGame();
        }
        if (Time.timeScale == 0) return;
        
        if (alienCounter == 0)
        {
            GameWon();
        }
    }

    public void ScoreUpdater()
    {
        score++;
        alienCounter--;
        UpdateScoreScreen();
    }

    public void UpdateScoreScreen()
    {
        _score.text = "Score: " + score;
        _alienCounter.text = "Aliens Left: " + alienCounter;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseScreen.SetActive(true);
        _crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _audioSourcebg.Stop();
    }

    public void ResumeGame()
    {
        Debug.Log("Resume");
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
        _crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _audioSourcebg.Play();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("AlienShooter");
    }

    public void GameWon()
    {
        Time.timeScale = 0;
        _winScreen.SetActive(true);
        _crosshair.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _audioSourcebg.Stop();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
        _audioSourcebg.Stop();
    }
}
