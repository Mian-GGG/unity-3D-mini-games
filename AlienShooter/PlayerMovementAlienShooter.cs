using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementAlienShooter : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject _camera, _gun;
    [SerializeField] ParticleSystem _muzzleFlash;
    AudioSource _audioSource, _audioSourceGunFire;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        _audioSourceGunFire = GameObject.Find("SciFiGunLight_Black").GetComponent<AudioSource>();
        _audioSource.Play();
    }

    void Update()
    {
        if (Time.timeScale == 0) return;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            StartCoroutine(StartRecoil());
            
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 1000f, Color.red);
                _audioSourceGunFire.Play();
                if (hit.transform.CompareTag("Target"))
                {
                    hit.transform.GetComponent<AlienExploder>().Explode();
                }
            }
            else
            {
                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 1000f, Color.green);
                
            }
            
            _muzzleFlash.Play();
        }

    }

    IEnumerator StartRecoil()
    {
        _gun.GetComponent<Animator>().Play("RecoilAnimation");
        yield return new WaitForSeconds(0.20f);
        _gun.GetComponent<Animator>().Play("New State");
    }
}