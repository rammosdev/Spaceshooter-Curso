using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputEventTrace;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pegar o método PerdeVida e aplicar o dano
        if (collision.CompareTag("Inimigo1"))
            {
                collision.GetComponent<InimigoController>().PerdeVida(1);
            }

        if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().PerdeVida(1);
            }
        Destroy(gameObject);
    }
}
