using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singelton<PlayerController>
{
    [SerializeField] float movementSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCoolDown;

    bool isDashing;

    Animator animator;             // Refrence to the Animator component.
    SpriteRenderer sr;             // Refrence to the SpriteRenderer component.
    Rigidbody2D rb;                // Refrence to the Rigitbody component.
    PlayerControls playerControls; // Refrence to the PlayerControls **ACTION MAP** .
    TrailRenderer trailRenderer;   // Refrence to the TrailRenderer component that belong to the trail child game object.
    private Vector2 movement;      // We using that to store our value incoming from our playerControls input.


    
    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void Start()
    {
        playerControls.Movement.Dash.performed += _ => Dashing();
    }

    // When we use the new input system - we need to ENABLE the action map that we want to use.
    private void OnEnable()
    {
        playerControls.Enable();
    }
   

    // This funcion will be performed on the Update Method - because this funcion will READ the input from our playerConrols action map.
    void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);

    }


    // This funcion will be performed on the FixedUpdate Method - because this funcion will move the player.
    // This funcion use the 'movement' Vector2 from the PlayerInput() funcion.
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (movementSpeed * Time.fixedDeltaTime));
    }

    
    void AdjustPlayerFacing()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        // (If the mouse is Left to our player)
        if (mousePosition.x < playerScreenPoint.x)
        {
            sr.flipX = true;
        } else // (If the mouse is Right to our player)
        {
            sr.flipX = false;
        }
    }

    
    // Those two functions below are belong to the DASH and the TrailRenderer while DASHING.
    void Dashing()
    {
        if (!isDashing)
        {
            isDashing = true;
            movementSpeed *= dashSpeed;
            trailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }    
    }
    
    IEnumerator EndDashRoutine()
    {
        yield return new WaitForSeconds(dashDuration);
        movementSpeed /= dashSpeed; 
        trailRenderer.emitting = false;
        yield return new WaitForSeconds(dashCoolDown);
        isDashing = false;
    }

    // We often use the Update Method to read input.
    // After we read the input from Update Method -> We using those information on our FixedUpdate Method.
    // On General - When we want to perform some physics -> We gonna do it on FixedUpdate.
    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacing();
        Move();
    }

}
