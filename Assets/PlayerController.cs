using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;

    public Vector2 moveDir;

    public Transform cm;

    public Vector3 targetDir;

    public Vector3 motionVec;

    public int currentGarbage = -1;

    public Text count;

    private bool E;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cm = Camera.main.transform;
    }


    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");

        TransRotate();
    }

    void TransRotate() 
    {
        if (moveDir.magnitude > 0.1f) 
        {
            Vector3 f = cm.forward;
            Vector3 r = cm.right;

            f.y = 0;
            r.y = 0;

            targetDir = (f * moveDir.y + r * moveDir.x).normalized;

            transform.forward = Vector3.Slerp(transform.forward,targetDir,0.2f);
        }
    }

    void FixedUpdate() 
    {
        if (moveDir.magnitude > 0.1f)
        {
            if (Vector3.Angle(transform.forward, targetDir) > 10)
                return;


            rb.position += transform.forward * motionVec.magnitude;
            motionVec = Vector3.zero;
        }   
    }

    void LateUpdate() 
    {
        anim.SetFloat("speed",moveDir.magnitude);
    }

    void OnAnimatorMove() 
    {
        motionVec += anim.deltaPosition;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("g"))
        {
            if (currentGarbage > 0)
            {

            }
            else
            {
                currentGarbage = other.GetComponent<Garbage>().id;
                Destroy(other.gameObject);
            }
            //
        }
        else if (other.CompareTag("gc") && currentGarbage > 0) 
        {

            int _id = other.GetComponent<GarbageCan>().id;
            if (currentGarbage == _id)
            {
                count.text = "+1";
                count.gameObject.SetActive(true);
                currentGarbage = -1;
            }
            else 
            {
                count.text = "-1";
                count.gameObject.SetActive(true);
                currentGarbage = -1;
            }
        }
    }

}
