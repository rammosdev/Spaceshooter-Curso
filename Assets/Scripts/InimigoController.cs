using UnityEngine;

public class InimigoController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    
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

    void Movimentação()
    {

    }
}
