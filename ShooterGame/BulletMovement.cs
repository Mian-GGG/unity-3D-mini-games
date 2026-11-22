using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector2 turn;
    [SerializeField]
    private float _speedOfBullet;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        transform.position += transform.forward * _speedOfBullet * Time.deltaTime;

        if (this.gameObject.transform.position.z >= 4.8f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(this.gameObject);
            CapsuleCollider _bcOther = other.gameObject.GetComponent<CapsuleCollider>();
            _bcOther.isTrigger = false;

            Rigidbody _rbOther = other.gameObject.GetComponent<Rigidbody>();
            _rbOther.useGravity = true;
            CrosshairMovement._score++;
        }
    }
}
