using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 7;
    public float jumpStrength = 400;

    Vector3 startPosition = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            rb.AddForce(new Vector2(0, jumpStrength));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = startPosition;
            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startPosition;
        }

    }

    bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, LayerMask.GetMask("ground"));
        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}
