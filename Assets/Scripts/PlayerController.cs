using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator animator;
    public static PlayerController instance;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        theRB.velocity = new Vector2(x, y) * moveSpeed;

        animator.SetFloat("moveX", theRB.velocity.x);
        animator.SetFloat("moveY", theRB.velocity.y);

        var isMovingRight = x == 1;
        var isMovingLeft = x == -1;
        var isMovingDown = y == 1;
        var isMovingUp = y == -1;

        if (isMovingRight || isMovingLeft || isMovingDown  || isMovingUp)
        {
            animator.SetFloat("lastMoveX",  x);
            animator.SetFloat("lastMoveY",  y);
        }
    }
}
