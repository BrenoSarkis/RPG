using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator animator; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        theRB.velocity = new Vector2(x, y) * moveSpeed;
        animator.SetFloat("moveX", x);
        animator.SetFloat("moveY", y);
    }
}
