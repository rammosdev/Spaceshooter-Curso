using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimenta��o();
    }

    public void Movimenta��o()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector2 mySpeed = new Vector2(horizontal, vertical) * speed;
        mySpeed.Normalize();
        Debug.Log(mySpeed);
        rb.linearVelocity = mySpeed * speed;
    }
}
