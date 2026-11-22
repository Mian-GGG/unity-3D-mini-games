using UnityEngine;

public class AlienExploder : MonoBehaviour
{
    [SerializeField] GameObject _alien, _alienBroken;
    UIControlAlienShooter scriptUI;
    bool _isDead = false;

    void Start()
    {
        scriptUI = GameObject.Find("MainCanvas").GetComponent<UIControlAlienShooter>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
    }

    public void Explode()
    {
        _alien.SetActive(false);
        _alienBroken.SetActive(true);
        if (_isDead != true)
        {
            scriptUI.ScoreUpdater();
        }
        _isDead = true;

        Destroy(_alienBroken, 2f);
    }

}
