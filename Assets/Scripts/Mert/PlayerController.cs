using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;
    private void Awake()
    {
        animator = transform.GetChild(1).GetComponent<Animator>();
        #region instance Control
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        #endregion

    }

    Animator animator;

    public float playerSpeed;

    public DynamicJoystick dynamicJoystick;

    Rigidbody rb;

    Vector3 direction;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        transform.position += new Vector3(dynamicJoystick.Horizontal * Time.deltaTime * playerSpeed, 0, dynamicJoystick.Vertical * Time.deltaTime * playerSpeed);
        direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        if (direction != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(-direction * playerSpeed * Time.fixedDeltaTime);
            animator.SetBool("run", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("run", false);
        }
    }
}
