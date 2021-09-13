using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SawScript ss = collision.gameObject.GetComponent<SawScript>();
            ss.speed *= -1;
        }
    }
}
