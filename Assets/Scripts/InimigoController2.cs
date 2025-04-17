using UnityEngine;

public class InimigoController2 : InimigoPai
{
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
