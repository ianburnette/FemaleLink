using UnityEngine;
using System.Collections;

public class PlayerControlsInput : MonoBehaviour {

	public float h, v, moveSpeed, rayDist;
	public LayerMask movementCollisionMask;
	public bool moving, facingCamera, facingRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 inputVector = GetMovementInput ();
		Vector2 movementVector = DetermineMovementCollisions (inputVector);
		ApplyMovement (movementVector);
	}

	Vector2 GetMovementInput(){
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");
		return new Vector2 (h, v);
	}

	Vector2 DetermineMovementCollisions(Vector2 intendedVector){
		Vector2 vectorToMove = Vector2.zero;
		RaycastHit2D horizontalHit = Physics2D.Raycast (transform.position, new Vector2 (intendedVector.x, 0f), rayDist, movementCollisionMask);
		RaycastHit2D verticalHit = Physics2D.Raycast (transform.position, new Vector2 (0f, intendedVector.y), rayDist, movementCollisionMask);
		if (horizontalHit.transform == null) 
			vectorToMove = new Vector2 (intendedVector.x, vectorToMove.y);
		if (verticalHit.transform == null) 
			vectorToMove = new Vector2 (vectorToMove.x, intendedVector.y);
		if (vectorToMove.x != 0 && vectorToMove.y != 0) {
			vectorToMove = new Vector2(vectorToMove.x/1.5f, vectorToMove.y/1.5f); 
		}
		return vectorToMove;
	}

	void ApplyMovement(Vector2 vectorToMove){
		transform.Translate (vectorToMove * moveSpeed * Time.deltaTime);
		CalculateAnimation (vectorToMove);
	}

	void CalculateAnimation (Vector2 movementVector){
		if (movementVector != Vector2.zero)
			moving = true;
		else
			moving = false;
		if (movementVector.x > 0) 
			facingRight = true;
		else if (movementVector.x < 0) 
			facingRight = false;
		if (movementVector.y > 0) 
			facingCamera = false;
		else if (movementVector.y <= 0)
			facingCamera = true;
		
	}

}
