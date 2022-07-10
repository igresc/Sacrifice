using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D circleCollider;
	[HideInInspector] public bool isRespawn = false;
	public GameObject birdDeath;
	bool isFacingRight;


	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

	private void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	public void Throw(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
		Flip();
	}

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}
	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != "Player")
		{
			DesactivateRb();
			isRespawn = true;
		}
		else
		{
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Enemies"))
		{

			Die();
		}
	}

	public void Die()
	{
		SacrificialCounter.birdosSacrified++;
		Instantiate(birdDeath, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}

	void Flip()
	{
		if(isFacingRight && rb.velocity.x <= 0f || !isFacingRight && rb.velocity.x >= 0f)
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}
	}
}
