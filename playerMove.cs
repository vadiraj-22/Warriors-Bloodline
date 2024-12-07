using UnityEngine;

public class player : MonoBehaviour
{
    public int maxHealth = 3;
    public Animator animator;
    public float jumpheight = 5f;
    public Rigidbody2D rb;
    private float movement;
    public float movespeed = 5f;
    private bool facingright = true;
    private bool isGrounded = true; // To check if the player is on the ground

    // Update is called once per frame
    void Update()
    
    {
        if(maxHealth <= 0) {
            Die();
        }
        // Get horizontal input
        movement = Input.GetAxis("Horizontal");

        // Flip the player based on movement direction
        if (movement < 0f && facingright) // Moving left and currently facing right
        {
            Flip();
        }
        else if (movement > 0f && !facingright) // Moving right and currently facing left
        {
            Flip();
        }

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Jump only when grounded
        {
            Jump();
            isGrounded=false;
            animator.SetBool("jump",true);
        }

        if(Mathf.Abs(movement) > 0.1f)
        {
            animator.SetFloat("run",1f);
        }
        else if(movement < 0.1f){
            animator.SetFloat("run",0f);
        }

        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger("attack");
        }
    }

    // FixedUpdate is called at a fixed time interval
    private void FixedUpdate()
    {
        // Move the player using Rigidbody2D velocity
        rb.linearVelocity = new Vector2(movement * movespeed, rb.linearVelocity.y);
    }

    // Function to flip the player
    private void Flip()
    {
        facingright = !facingright; // Toggle the facing direction
        transform.eulerAngles = new Vector3(0f, facingright ? 0f : 180f, 0f); // Flip the rotation
    }

    // Jump Function
    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpheight), ForceMode2D.Impulse); // Apply upward force
        isGrounded = false; // Set grounded state to false
    }

    // Check if the player is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) // Ensure ground objects are tagged as "Ground"
        {
            isGrounded = true; // Reset grounded state
            animator.SetBool("jump",false);
        }
    }
   public void TakeDamage(int damage)
{
    if (maxHealth > 0)
    {
        maxHealth -= damage;
        Debug.Log("Player took damage. Current Health: " + maxHealth);

        if (maxHealth <= 0)
        {
            Die(); // Call Die() when health reaches 0
        }
    }
}


    void Die () {
        Debug.Log("Player Died.");
    }
}
