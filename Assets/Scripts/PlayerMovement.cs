using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    PlayerHealth playerHealth;

    bool isAlive = true;
    float gravityScaleAtStart;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        playerHealth = GetComponent<PlayerHealth>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }

        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }


        if (value.isPressed)
        {
            myBodyCollider.size = new Vector2(myBodyCollider.size.x, 1.2076f);
            myBodyCollider.offset = new Vector2(-0.03613f, -0.0075f);
            myFeetCollider.size = new Vector2(myFeetCollider.size.x, myFeetCollider.size.y);
            myFeetCollider.offset = new Vector2(myFeetCollider.offset.x, -0.6312624f);
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
            myAnimator.SetBool("IsJumping", true);
            myAnimator.SetBool("IsCrawling", false);
        }


    }

    void OnCrawl(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        // bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        // if (playerHasHorizontalSpeed) { return; }
        if (myAnimator.GetBool("IsCrawling"))
        {
            myAnimator.SetBool("IsCrawling", false);
            myBodyCollider.size = new Vector2(myBodyCollider.size.x, 1.2076f);
            myBodyCollider.offset = new Vector2(-0.03613f, -0.0075f);
            myFeetCollider.size = new Vector2(myFeetCollider.size.x, myFeetCollider.size.y);
            myFeetCollider.offset = new Vector2(myFeetCollider.offset.x, -0.6312624f);
        }
        else
        {
            myAnimator.SetBool("IsCrawling", true);
            myBodyCollider.size = new Vector2(myBodyCollider.size.x, 0.76199f);
            myBodyCollider.offset = new Vector2(-0.03613f, -0.23035f);
            myFeetCollider.size = new Vector2(myFeetCollider.size.x, myFeetCollider.size.y);
            myFeetCollider.offset = new Vector2(myFeetCollider.offset.x, -0.5849594f);
        }


    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        bool isTouchingGround = myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        myAnimator.SetBool("IsRunning", playerHasHorizontalSpeed && isTouchingGround);
        myAnimator.SetBool("IsJumping", !isTouchingGround);
        {

        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    // void ClimbLadder()
    // {
    //     if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))

    //     {
    //         myRigidBody.gravityScale = gravityScaleAtStart;
    //         myAnimator.SetBool("IsClimbing", false);
    //         return;
    //     }

    //     Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, moveInput.y * climbSpeed);
    //     myRigidBody.velocity = climbVelocity;
    //     myRigidBody.gravityScale = 0f;
    //     bool playerVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

    //     myAnimator.SetBool("IsClimbing", playerVerticalSpeed);
    // }
    void Die()
    {
        if (playerHealth.health <= 0)
        {
            isAlive = false;

        }
    }
}
