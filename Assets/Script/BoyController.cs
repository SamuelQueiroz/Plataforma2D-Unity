using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour {

	public float jumpForce;

	[Header("Scene References")]
	public Transform groundCheck;

	[Header("Movement")]
	private float pixelToUnit = 40f;
	public float maxVelocity = 500f; // pixels/seconds
	public Vector3 moveSpeed = Vector3.zero; // (0,0,0)

	[Header("Animation")]
	public bool isFacingLeft = false;
	public bool isRunning = false;
	//public bool isGrounded = false;
	//public bool isFalling = false;
	//public bool setJumpTrigger = false;
	//public bool setFallTrigger = false;
	//public bool setLandTrigger = false;

	[Header("Components")]
	public Rigidbody2D rigidbody2D;
	public SpriteRenderer spriterenderer;
	public Animator animator;

	// Update is called once per frame
	void Update () {
		UpdateAnimatorParameters ();
		HandleHorizontalMovement ();
		HandleVerticalMovement ();
		MoveCharacterController ();
	}

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		spriterenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}

	void UpdateAnimatorParameters() {
		animator.SetBool ("isRunning", isRunning);
		/*
		if (setJumpTrigger) {
			animator.SetTrigger ("Jump");
			setJumpTrigger = false;
		} else 
		{
			animator.ResetTrigger ("Jump");
		}

	*/

	}

	void HandleHorizontalMovement() {
		moveSpeed.x = Input.GetAxis ("Horizontal") * (maxVelocity / pixelToUnit);
		/*
		if (RaycastAgainstLayer ("Ground", groundCheck))
		{
			//Acertou o chao
			isGrounded = true;
			*/
			if (moveSpeed.x != 0f) {
				isRunning = true;

			} else {
				isRunning = false;
			}
			
		/*
		else 
		{
			isGrounded = false;
			isRunning = false;
		} */

		if (Input.GetAxis ("Horizontal") < 0 && !isFacingLeft) {
			// Muda o megaman para esquerda
			isFacingLeft = true;
		} else if (Input.GetAxis ("Horizontal") > 0 && isFacingLeft) {
			// Muda o megaman para direita
			isFacingLeft = false;
		}

		spriterenderer.flipX = isFacingLeft;
	}

	void HandleVerticalMovement() {
		moveSpeed.y = rigidbody2D.velocity.y;

	/*	if (isGrounded) {
			//Esta no chao?

		//	if (isFalling) {
				//Esta caindo?
		//		setLandTrigger = true;
		//		isFalling = false;
			 if (Input.GetKeyDown (KeyCode.Space)) {
				//Faz pulo
				rigidbody2D.AddForce (Vector2.up * jumpForce);
				setJumpTrigger = true;
				isGrounded = false;
			}
		} else 
		{
			//se eu não estou no chao
			if (moveSpeed.y < 0f && !isFalling) 
			{
				isFalling = true;
				setFallTrigger = true;
			}

		} */
		
	}

	void MoveCharacterController() {
		rigidbody2D.velocity = moveSpeed;
	}

	/*
	RaycastHit2D RaycastAgainstLayer (string layerName, Transform endPoint){

		int layer = LayerMask.NameToLayer (layerName);
		int layerMask = 1 << layer; // camada 2 -> 100, camada 4 -> 1000

		// camadas 2,4 // (1 << 2) + (1 << 4) // 100 + 10000 = 10100

		Vector2 originPosition = new Vector2 (transform.position.x, transform.position.y);

		Vector2 direction = endPoint.localPosition.normalized;

		float rayLength = Mathf.Abs (endPoint.localPosition.y);

		RaycastHit2D hit2D = Physics2D.Raycast (originPosition, direction, rayLength, layerMask);

		return hit2D;

	} */
}
