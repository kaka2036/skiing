using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeedY;

    bool Jumping;
    bool Grounded;

    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   void Update()
    {
        HandleJumpAndFall();

        if (Input.GetKeyDown(KeyCode.J) && Grounded)
        {
            Jumping = true;
            Grounded = false;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Ground"))
        {
            Jumping = false;
            Grounded = true;
            anim.SetInteger("State", 1);
        }
    }

    void HandleJumpAndFall()
    {
        if(Jumping)
        {
            if(rb.velocity.y > 0)
            {
                anim.SetInteger("State", 2);
            }
            else 
            {
                anim.SetInteger("State", 3);
            }

        }
    }

}
