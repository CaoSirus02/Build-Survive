using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("References")]
    [SerializeField] LayerMask whatStopsMovement;
    [SerializeField] LayerMask whatStopsMovement2;
    [SerializeField] Transform movePoint;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;

    [Header("Attributes")]
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        Movement();
        Animation();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),
                    .2f, whatStopsMovement | whatStopsMovement2)) // Stops if encounter with collider
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f,
                    whatStopsMovement | whatStopsMovement2)) // Stops if encounter with collider
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
            //anim.SetBool("moving", false);
        }
        else
        {
            //anim.SetBool("moving", true);
        }
    }

    void Animation()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            spriteRenderer.sprite = spriteDown;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = spriteRight;
        }
        if( Input.GetKeyDown(KeyCode.W))
        {
            spriteRenderer.sprite = spriteUp;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = spriteLeft;
        }
    }
}
