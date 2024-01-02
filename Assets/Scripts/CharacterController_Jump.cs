using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Jump : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 10.0f;
    private float moveDirection;
    private bool jump;
    private bool grounded = true;
    private bool isMoving;
    private Rigidbody2D _rgd2;
    private Animator _animator;
    private SpriteRenderer _spriteRanderer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _rgd2 = GetComponent<Rigidbody2D>();
        _spriteRanderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rgd2.velocity != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        _rgd2.velocity = new Vector2(speed * moveDirection, _rgd2.velocity.y);
        if (jump == true)
        {
            _rgd2.velocity = new Vector2(speed * moveDirection, jumpForce);
            jump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRanderer.flipX = true;
                _animator.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRanderer.flipX = false;
                _animator.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }
        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _animator.SetBool("grounded", true);
            grounded = true;
        }

    }
}

