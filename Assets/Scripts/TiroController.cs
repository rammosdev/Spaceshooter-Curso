using UnityEngine;

public class TiroController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
