using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	PlayerControlsInput controlScript;
	Animator anim;

	// Use this for initialization
	void Start () {
		controlScript = GetComponent<PlayerControlsInput> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("moving", controlScript.moving);
		anim.SetBool ("facingCamera", controlScript.facingCamera);
		if (controlScript.facingRight && transform.localScale.x < 0)
			transform.localScale = new Vector3 (1, 1, 1);
		else if (!controlScript.facingRight && transform.localScale.x > 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	}
}
