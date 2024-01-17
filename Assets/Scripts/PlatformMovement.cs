using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public KeyCode rightKey, leftKey;
    public float speed;
    public AudioClip stepSound;

    private Rigidbody2D _rb;
    private Vector2 _dir;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Boolean isJumping;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _dir = Vector2.zero;
        if (Input.GetKey(leftKey))
        {

            _dir = new Vector2(-1, 0);
            _spriteRenderer.flipX = true;

        }
        else if (Input.GetKey(rightKey))
        {

            _dir = new Vector2(1, 0);
            _spriteRenderer.flipX = false;
        }

    // If salto 

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _rb.AddForce(Vector2.up * 40, ForceMode2D.Impulse);

            isJumping = true;
        }

      //IF de animaciones

        if(_dir != Vector2.zero)
        {
            _animator.SetBool("isWalking", true);
        }else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (_rb.velocity.y == 0)
        {
            isJumping = false;
        }
    }

    public void PlayStepSound()
    {
        AudioManager.instance.PlayAudio(stepSound, .5f);
    }

    private void FixedUpdate()
    {
        Vector2 nVel = _dir * speed;
        nVel.y = _rb.velocity.y;
        _rb.velocity = nVel;
    }
}
