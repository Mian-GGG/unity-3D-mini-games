using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void SwitchToRollingBall()
    {
        SceneManager.LoadScene("RollingBallGame");
    }
    public void SwitchToShooter()
    {
        SceneManager.LoadScene("ShooterGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchToAlienShooter()
    {
        SceneManager.LoadScene("AlienShooter");
    }
}
