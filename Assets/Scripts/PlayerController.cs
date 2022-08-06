using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D rb;
    private Animator anim;
    public Transform feetPos;
    public LayerMask whatIsGround;

    private bool facingRight = true;
    private bool isGrounded;

    public float speed;
    public float jumpForce;
    public float checkRadius;
    public bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    public int health;

    private HealthBar healthBar;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetHealth(health);
    }

    private void Update()
    {
        if (health <= 0)
        {
          //  Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
     
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        var horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 moveInput = new Vector2(horizontal, 0);

        if (facingRight && horizontal < 0)
        {
            Flip();
        }
        else if (!facingRight && horizontal > 0)
        {
            Flip();
        }

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage(int damage)
    {
       // camAnim.SetTrigger("shake");
      //  Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
        healthBar.SetHealth(health);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSecondsRealtime(dashingTime);

        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSecondsRealtime(dashingCooldown);
        canDash = true;
    }
}
