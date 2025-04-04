using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;

    public AudioClip jumpSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

	playerAudio = GetComponent<AudioSource>();

	if (GroundCheck == null)
	    Debug.LogError("GroundCheck not assigned to the player controller!");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
	isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);

	if (horizontalInput > 0)
	    transform.localScale = new Vector3(1f, 1f, 1f);
	else if (horizontalInput < 0)
	    transform.localScale = new Vector3(-1f, 1f, 1f);
    }
}
