using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float crouch;
    [SerializeField] private float smoothTime;
    [SerializeField] private float jumpForse;
    [SerializeField] private GameObject playerCamera;
    [Space]
    [Header("Health")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite [] healthImages;
    [SerializeField] private  int health = 10;
    private bool isGround;
    private Vector3 moveAmount;
    private Vector3 smoothMove;
    private Rigidbody rb;
    private float verticalLookRotation;
    private Animator animator;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GameObject.Find("AnimationLibrary_Unity_Standard").GetComponent<Animator>();
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed), ref smoothMove, smoothTime);
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void Update()
    {
        Move();
        Look();
        Jump();
    }

    private void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -80f, 90f);
        playerCamera.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpForse, ForceMode.Impulse);
            isGround = false;
        }
        else
        {
            animator.SetTrigger("IsLanded");
        }
    }

    // public void GroundState(bool isGround)
    // {
    //     this.isGround = isGround;
    // }

    private void OnCollisionEnter()
    {
        isGround = true;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
