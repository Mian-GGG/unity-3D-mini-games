using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrosshairMovement : MonoBehaviour
{
    public Vector2 turn;
    [SerializeField]
    private GameObject _bullet, _crosshair, _panel, _winScreen, _pauseScreen;
    public static int _score = 0;
    public static TextMeshProUGUI _scoreBoard;
    public TextMeshProUGUI _timer;
    private float _countDown = 20;
    private bool _isGameRunning = true;
    AudioSource _audioSourcebg, _audioSourceFiring;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _scoreBoard = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _panel.SetActive(false);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        _score = 0;
        Time.timeScale = 1;
        _audioSourcebg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        _audioSourceFiring = GameObject.Find("Crosshair").GetComponent<AudioSource>();
        _audioSourcebg.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (Time.timeScale == 0) return;
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        _scoreBoard.text = "Score: " + _score;

        if (_isGameRunning)
        {

            transform.localRotation = Quaternion.Euler(Mathf.Clamp(-turn.y, -26, 14), Mathf.Clamp(turn.x, -26, 26), 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _isGameRunning)
        {
            Instantiate(_bullet, transform.position, Quaternion.Euler(Mathf.Clamp(-turn.y, -26, 14), Mathf.Clamp(turn.x, -26, 26), 0));
            _audioSourceFiring.Play();
        }


    }
    private void FixedUpdate()
    {
        if (_score != 20)
        {
            if (_countDown > 0)
            {
                _countDown -= Time.fixedDeltaTime;

                _timer.text = "Time Left: " + Mathf.Round(_countDown);

            }
            else
            {
                _panel.SetActive(true);
                _crosshair.SetActive(false);
                _isGameRunning = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            _winScreen.SetActive(true);
            _crosshair.SetActive(false);
            _isGameRunning = false;
            Cursor.lockState = CursorLockMode.None;
            _timer.text = "Time Left: 00";
        }

    }

    public void StartGameAgain()
    {
        SceneManager.LoadScene("ShooterGame");
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

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseScreen.SetActive(true);
        _crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        _audioSourcebg.Stop();
    }
    public void ResmueGame()
    {
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
        _crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        _audioSourcebg.Play();
    }
}