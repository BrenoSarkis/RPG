﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator animator;
    public static PlayerController instance;
    public string areaTransitionName;
    public bool canMove = true;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            theRB.velocity = new Vector2(x, y) * moveSpeed; 

        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        animator.SetFloat("moveX", theRB.velocity.x);
        animator.SetFloat("moveY", theRB.velocity.y);

        var isMovingRight = x == 1;
        var isMovingLeft = x == -1;
        var isMovingDown = y == 1;
        var isMovingUp = y == -1;

        if (isMovingRight || isMovingLeft || isMovingDown  || isMovingUp)
        {
            if (canMove)
            {
                animator.SetFloat("lastMoveX", x);
                animator.SetFloat("lastMoveY", y);
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
                                         Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
                                         transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(0.5f, 0.8f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -0.8f, 0f);
    }
}
