using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    bool facingRight = true;
    float objectWidth;
    float objectHeight;

    Rigidbody2D _rigidbody2D;
    public Animator animator;

    float horizontalMovement;
    float verticalMovement;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    void FixedUpdate()
    {
        
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed;
        _rigidbody2D.velocity = new Vector2(horizontalMovement, verticalMovement);

        animator.SetFloat("Speedx", Mathf.Abs(horizontalMovement));
        animator.SetFloat("Speedy", Mathf.Abs(verticalMovement));

        RestrictMovement();
    }
    void Update()
    {
        FlipCheck();
    }
    void FlipCheck()
    {
        if (facingRight == false && horizontalMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && horizontalMovement < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void RestrictMovement()
    {
        Vector3 upperRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 lowerLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        float restrictedX = Mathf.Clamp(transform.position.x, lowerLeftCorner.x + objectWidth, upperRightCorner.x - objectWidth);
        float restrictedY = Mathf.Clamp(transform.position.y, lowerLeftCorner.y + objectHeight, upperRightCorner.y - objectHeight);

        transform.position = new Vector3(restrictedX, restrictedY, 0);
    }
}
