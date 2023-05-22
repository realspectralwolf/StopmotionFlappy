using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float gravityOverSpeed = 0.2f;
    [SerializeField] float jumpForce = 20;
    [SerializeField] float jumpOverSpeed = 0.12f;
    float fallVelocity = 0;

    public event System.Action OnJumped;

    // Start is called before the first frame update
    void Start()
    {
        initialGravity = gravity;
        initialJumpForce = jumpForce;
        initialGameSpeed = GameManager.instance.moveSpeed;
    }

    private float initialGameSpeed;
    private float initialGravity;
    private float initialJumpForce;

    // Update is called once per frame
    void Update()
    {
        float a = 1 + gravityOverSpeed * (GameManager.instance.moveSpeed - initialGameSpeed);
        gravity = initialGravity * a;

        float b = 1 + jumpOverSpeed * (GameManager.instance.moveSpeed - initialGameSpeed);
        jumpForce = initialJumpForce * b;

        fallVelocity -= gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("JumpAlt"))
        {
            fallVelocity = jumpForce;
            OnJumped?.Invoke();
        }

        transform.position += Vector3.up * fallVelocity * Time.deltaTime;
    }
}
