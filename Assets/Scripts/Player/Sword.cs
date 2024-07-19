using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    [SerializeField] GameObject slashAnimationPrefab;
    [SerializeField] Transform slashAnimationSpawnPoint;
    [SerializeField] Transform swordHittingCollider;


    private GameObject slashAnim;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    [SerializeField] bool swordFacingLeft;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
    }

    private void Start()
    {
        // .started: This is a part of the new input system's event handling mechanism.
        // It represents the moment when the associated input action (in this case, "Attack") has started (e.g., when the button/key is pressed down).
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Update()
    {
        FlipSwordAccordingToMousePosition();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    void Attack()
    {
        myAnimator.SetTrigger("Attack");
        swordHittingCollider.gameObject.SetActive(true);       // The sword hitting collider should be active ONLY when player attack.
        slashAnim = Instantiate(slashAnimationPrefab, slashAnimationSpawnPoint.position, Quaternion.identity);
       // slashAnim.transform.parent = this.transform.parent;
    }   



    // This funcion is Animation Event.
    // We add this Event to both animation: "Swing Up" and "Swing Down".
    public void StopAttackAfterAnimationEvent()
    {
        swordHittingCollider.gameObject.SetActive(false);
    }

    // This funcion is Animation Event.
    // This Event will makes the slash animation to "Swing Up" for both sides - Right AND Left.
    public void SwingUpSlashAnimation()
    {
        if (!swordFacingLeft)
        {
            slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);
        }
        else
        {
            slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, -180, 0);
        }
    }

    // This funcion is Animation Event.
    // This Event will makes the slash animation "Swing Up" when the player facing left.
    public void SwingDownLeftSideAnimation()
    {
        if (swordFacingLeft)
        {
            slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    
    void FlipSwordAccordingToMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        if (mousePosition.x < playerScreenPoint.x)
        {
            // Change the ROTATION of the activeWeapon game object.
            // Set the Rotation to: x = 0 , y = -180 , z = 0;
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            swordHittingCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
            swordFacingLeft = true;
        } else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            swordHittingCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
            swordFacingLeft = false;
        }
    }
}
