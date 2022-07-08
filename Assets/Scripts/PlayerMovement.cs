using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	float horizontal;
	float speed = 8f;
	float jumpingPower = 10f;
	bool isFacingRight = false;

	[SerializeField] public float fallMultiplier = 6f;
	[SerializeField] public float lowJumpMultiplier = 5.5f;

	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundLayer;

	public Animator anim;

	private void Start()
	{
		isFacingRight = false;
		transform.localScale = Vector3.one;
	}

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		if(Input.GetButtonDown("Jump") && IsGrounded())
		{
			//rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
			rb.velocity = Vector2.up * jumpingPower;
		}


		if(horizontal == 0f && IsGrounded())
		{
			anim.SetBool("isIdle", true);
			anim.SetBool("isRunning", false);
		}
		else
		{
			anim.SetBool("isIdle", false);
			anim.SetBool("isRunning", true);
		}

		Flip();
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

		if(rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; // -1 acount for the physics system normal gravity
		}
		else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; // -1 acount for the physics system normal gravity
		}

	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	void Flip()
	{
		if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}
	}

}