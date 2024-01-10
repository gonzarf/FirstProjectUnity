using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;
    private Vector2 _direction;
    private Vector2 _initialPos;

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction.y = -_direction.y;

        if (collision.gameObject.GetComponent<pinpanpum>())
        {
            // me he chocado con la pala
            _direction.y = Random.Range(-1, 2);
            _direction.x = -_direction.x;
        }
    }

    public void ResetBall()
    {
        transform.position = _initialPos;
        _direction.y = Random.Range(-1, 2);

        do
        {
            _direction.x = Random.Range(-1, 2);
        } while (_direction.x == 0);
    }
}
