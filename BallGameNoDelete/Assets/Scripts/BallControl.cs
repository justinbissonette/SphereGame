using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rigid;
    public float jump = 500;
    public float gravitypull = 300;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * speed);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(Vector3.left * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.forward * speed);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            rigid.AddForce(Vector3.back * speed);
        }

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jumping());
        }
    }

    IEnumerator Jumping()
    {
        rigid.AddForce(Vector3.up * jump);
        yield return new WaitForSeconds(.5F);
        rigid.AddForce(Vector3.down * gravitypull);
    }
}