using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    
    private float speed = 5f;
    private GroundCheck gndck;

    public bool hit = false;
    public bool isGrounded = false;
    private bool onEffector = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gndck = GetComponent<GroundCheck>();
        anim = GetComponent<Animator>();
    }

    

    private void FixedUpdate()
    {
       
        float hInput = Input.GetAxis("Horizontal");
        if (!onEffector)
        {

            rb.linearVelocity = new Vector2(hInput * speed, rb.linearVelocity.y);//player movement
        }
        else
        {
            rb.AddForce(Vector2.right * hInput * speed, ForceMode2D.Force);//lets player fight against effector
        }

        //sprite flipping(right to left)
        if (hInput != 0) sr.flipX = (hInput < 0);

        anim.SetFloat("speed", Mathf.Abs(hInput));
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("Hit", hit);

    }

    private void Update()
    {
        CheckIsGrounded();
        
    }

    void CheckIsGrounded()
    {
        if (!isGrounded)
        {
            if (rb.linearVelocity.y <= 0) isGrounded = gndck.isGrounded();

        }
        else
            isGrounded = gndck.isGrounded();
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("MovingGround"))//checking if on effector moving ground
            onEffector = true;
        if(collision.gameObject.CompareTag("Saw"))
        {
            GameManager.Instance.lives--;
            hit = true;
        }
        if(collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Hit");
            GameManager.Instance.Victory();
        }
        else
        hit = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("MovingGround"))//checking if leaving effector
            onEffector = false;
    }

}
