using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 300f;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField]
    float jumpBoost = 0f;
    bool isJumping = false;
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    private GameObject _winScreen, _pauseScreen, _startScreen;
    int coinCount = 0;
    AudioSource _audioSourcebg;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        coinCount = 0;
        _audioSourcebg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        _audioSourcebg.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused();
        }
        if (Time.timeScale == 0) return;
        movement = new Vector3(Input.GetAxis("Vertical"), rb.linearVelocity.y, -Input.GetAxis("Horizontal")).normalized;

        _score.text = "Score:" + coinCount;

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJumping == false)
            {
                Jump();
            }
        }
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector3 direction)
    {
        rb.linearVelocity = direction * speed * Time.fixedDeltaTime;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpBoost);
        isJumping = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Floor")
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            speed = 0f;
            _winScreen.SetActive(true);
            _audioSourcebg.Stop();
        }

        if (other.tag == "Coin")
        {
            coinCount++;
        }

    }

    public void GamePaused()
    {
        Time.timeScale = 0;
        _pauseScreen.SetActive(true);
        _audioSourcebg.Stop();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
        _audioSourcebg.Play();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
        _audioSourcebg.Stop();
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("RollingBallGame");
        Time.timeScale = 1;
        _audioSourcebg.Stop();
    }

    public void StartGame()
    {
        _startScreen.SetActive(false);
    }
}
