using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private CharacterController cc;

	public float moveSpeed;

	public float jumpSpeed;

	private float horizontalMove, verticalMove;

	private Vector3 dir;

	// 重力
	public float gravity;

	// 速度
	private Vector3 velocity;

	// 检测点的中心位置
	public Transform groundCheck;

	// 检测点的半径
	public float checkRadius;

	// 检测点的乘积
	public LayerMask groundLayer;

	public bool isGround;

	private Animator Anim;

	// Start is called before the first frame update
	void Awake()
	{
		Anim = GetComponent<Animator>();
	}

	// Use this for initialization
	private void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	private void Update () {
		
		
		isGround = Physics.CheckSphere (groundCheck.position, checkRadius, groundLayer);
		if (isGround && velocity.y < 0) {
			velocity.y = -2f;
		}

		horizontalMove = Input.GetAxis ("Horizontal") * moveSpeed;
		verticalMove = Input.GetAxis ("Vertical") * moveSpeed;
		// 把方向的信息存在dir中
		dir = transform.forward * verticalMove + transform.right * horizontalMove;
		// 移动player
		cc.Move(dir * Time.deltaTime*3/2);
	

		if (Input.GetButton ("Jump")) {
			velocity.y = jumpSpeed;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			Anim.SetBool ("isWalk", true);
		} else if(Input.GetKeyUp (KeyCode.W)){
			Anim.SetBool ("isWalk", false);
		}

		if(Input.GetKeyDown (KeyCode.Space)) {
			Anim.SetBool ("isJump", true);
		}else if(Input.GetKeyUp (KeyCode.Space)){
			Anim.SetBool ("isJump", false);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			Anim.SetBool ("isRun", true);
		} else if(Input.GetKeyUp (KeyCode.LeftShift)){
			Anim.SetBool ("isRun", false);
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			Anim.SetBool ("isSetDown", true);
		} else if(Input.GetKeyUp (KeyCode.LeftControl)){
			Anim.SetBool ("isSetDown", false);
		}
		velocity.y -= gravity * Time.deltaTime;
		cc.Move (velocity * Time.deltaTime);
	}
}
