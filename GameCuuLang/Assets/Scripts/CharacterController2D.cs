using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{

	[SerializeField] private float m_JumpForce = 400f;							//luc luong jump
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// thoi gian hoan thanh vi tri uoc muon , thoi lam muon chuyen dong
	[SerializeField] private LayerMask m_WhatIsGround = 0;							// nhung layer cho phep nhan vat nhay
	[SerializeField] private Transform m_GroundCheck = null;                            // vi tri duoi nhan vat , kiem tra checkground 
 

	const float k_GroundedRadius = .2f; // ban kinh vong tron vi tri duoi nhan vat checkground
	private bool m_Grounded;            // dang duoi dat hay tren khong
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // huong nhin cua nhan vat
	private Vector2 m_Velocity = Vector2.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandJumpEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	



	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandJumpEvent == null)
			OnLandJumpEvent = new UnityEvent();

		
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		
		Collider2D colliders = Physics2D.OverlapCircle(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		if(colliders != null)
        {	if(colliders.gameObject != gameObject)
			m_Grounded = true;
            if (!wasGrounded)
            {
				OnLandJumpEvent.Invoke();
			}
		}
        
    }


	public void Move(float move, bool jump)
	{
		

		//vi tri muon dat duoc
		Vector2 targetVelocity = new Vector2(move, m_Rigidbody2D.velocity.y);

		//public static Vector2 SmoothDamp ( Vector2 current , Vector2 target , ref Vector2 currentVelocity , float SmoothTime , float maxSpeed = Mathf.Infinity, float deltaTime = Time.deltaTime);
		//1: vi tri hien tai , 2: vi tri muon dat dc, 3: van toc hien tai, gia tri se dc thay doi khi goi ham, 4:khoang thoi gian de dat dc muc tieu (cang nho se dat dc nhanh hon),5: gioi han toc do  , 6: thoi gian ke tu lan cuoi goi ham nay
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