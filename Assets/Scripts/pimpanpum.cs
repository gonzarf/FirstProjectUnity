using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinpanpum : MonoBehaviour
{
    public float speed = 2;
    public KeyCode upkey, downkey;
    private Vector2 _direction;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction =Vector2.zero;
        if (Input.GetKey(upkey))
        {
            _direction = new Vector2(0, 1);

        }
        else if (Input.GetKey(downkey))
            {
 
                _direction = new Vector2(0, -1);
            }
    }

    void FixedUpdate() //Se usa para actualizar las fisicas del juego porque se actualiza mas de una vez
    {
        _rb.velocity = _direction * speed;
    }
}
