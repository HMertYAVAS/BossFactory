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

    BoxesController boxesController;
    Animator animator;
    public float playerSpeed;
    public DynamicJoystick dynamicJoystick;
    Rigidbody rb;
    public bool run;

    Vector3 direction;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        boxesController = GetComponent<BoxesController>();
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
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        PlayerAnimationControl();
    }

    void PlayerAnimationControl()
    {

        if ((dynamicJoystick.Horizontal + dynamicJoystick.Vertical) != 0 && run)
        {
            if (boxesController.BoxesListLine > 0 && run)
            {
                animator.SetTrigger("TransportationTrigger");
            }
            else
            {
                animator.SetTrigger("runningTrigger");
            }
            run = false;
        }
        else if (dynamicJoystick.Horizontal + dynamicJoystick.Vertical == 0 && !run)
        {
            if (boxesController.BoxesListLine > 0)
            {
                animator.SetTrigger("transportationDontwalkTrigger");
            }
            else
            {

                animator.SetTrigger("idleTrigger");
            }
            run = true;
        }

    }
}
