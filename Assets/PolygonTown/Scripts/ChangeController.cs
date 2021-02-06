using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
	private Animator Anim;

	// Start is called before the first frame update
	void Awake()
	{
		Anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W)) //向前
		{
			Anim.SetBool("isWalk", true);
		}else if (Input.GetKeyUp(KeyCode.W)) // 松手停止
		{
			Anim.SetBool("isWalk", false);
		}else if (Input.GetKeyDown(KeyCode.S))
		{
			Anim.SetBool("isWalk", false);
		}else if (Input.GetKeyDown(KeyCode.LeftShift))//跑步
		{
			Anim.SetBool("isRun", true);
		}else if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))//跑步
		{
			Anim.SetBool("isRun", false);
			Anim.SetBool ("isWalk", true);
		}else if (Input.GetKeyDown(KeyCode.Space))
		{
			Anim.SetBool("isJump", true);
		}else if (Input.GetKeyUp(KeyCode.Space))
		{
			Anim.SetBool("isJump", false);
		}

	}
}
