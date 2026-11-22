using UnityEngine;

public class CameaMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private Vector3 Offset;
    void Start()
    {
        Offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position + Offset;
        //transform.Rotate(0, _player.transform.eulerAngles.y, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0.5f, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -0.5f, 0);
        }
    }
}
