using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.6.12
/// </summary>

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("props")]
    [Tooltip("spped, force props")]
    [SerializeField]
    int speed, jumpForce;

    [SerializeField]
    bool isGrounded;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        speed = 300;
        jumpForce = 300;
        isGrounded = true;
        rigidbody.AddForce(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(0, jumpForce, 0);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
