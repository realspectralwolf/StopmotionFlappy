using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float jumpForce = 20;
    float fallVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fallVelocity -= gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
        }

        transform.position += Vector3.up * fallVelocity * Time.deltaTime;
    }
}
