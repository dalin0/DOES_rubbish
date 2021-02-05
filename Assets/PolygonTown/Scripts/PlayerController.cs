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

		if (Input.GetButton ("Jump") && isGround) {
			velocity.y = jumpSpeed;
		}

		velocity.y -= gravity * Time.deltaTime;
		cc.Move (velocity * Time.deltaTime);
	}
}
