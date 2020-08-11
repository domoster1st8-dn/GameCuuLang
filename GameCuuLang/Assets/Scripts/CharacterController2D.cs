using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private LayerMask m_WhatIsGround = 0;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck = null;							// A position marking where to check if the player is grounded. 


	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector2 m_Velocity = Vector2.zero;

	


	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		
	}

	private void FixedUpdate()
	{
		
		m_Grounded = false;
		
		Collider2D colliders = Physics2D.OverlapCircle(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		if(colliders.gameObject != gameObject)
        {
			m_Grounded = true;
        }
		//for (int i = 0; i < colliders.Length; i++)
		//{
		//	if (colliders[i].gameObject != gameObject)
		//	{
		//		m_Grounded = true;
		//		break;
		//	}

		//}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		

		//vi tri muon dat duoc
		Vector2 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
	
		 //1: vi tri hien tai , 2: vi tri muon dat dc, 3: van toc, 4:khoang thoi gian de dat dc muc tieu (cang nho se dat dc nhanh hon)
			m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// ben trai
			if (move > 0 && !m_FacingRight)
			{
				
				Flip();
			}
			// ben phai
			else if (move < 0 && m_FacingRight)
			{
				
				Flip();
			}
		
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f, 180f, 0f);
	}
}