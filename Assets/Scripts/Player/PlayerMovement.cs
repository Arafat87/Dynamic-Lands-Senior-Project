using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public CharacterController controller;

    public float speed;
    public float rotation = 10f;
    public Transform camera;

    public float dashSpeed;
    public KeyCode dashKey = KeyCode.Space;
    public bool doDamage = false;
    public bool touchingEnemy = false;
    int dashTime = 2;



    public Vector3 playerVelocity;


    public float gravity= -10f;
    private Animator anim;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    private void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
        if (Input.GetKeyUp(dashKey))
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

    }

    public void Movement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 zero = new Vector3(0, 0, 0);
        Vector3 movementInput = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;
        if (movementDirection == zero)
        {
            anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);

        }


        controller.Move(movementDirection * speed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotation * Time.deltaTime);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

 
    }
    public IEnumerator Attack()
    {
        doDamage = true;
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(2f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
        doDamage = false;
    }

    public IEnumerator Dash()
    {
        speed = 40f;
        yield return new WaitForSeconds(0.3f);
        speed = 12f;


    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy")){
            touchingEnemy = true;
        }
    }

}
