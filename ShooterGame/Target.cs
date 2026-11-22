using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.y <= -2.7f)
        {
            Destroy(this.gameObject);
        }
    }
}
