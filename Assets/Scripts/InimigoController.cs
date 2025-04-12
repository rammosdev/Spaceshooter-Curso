using UnityEngine;

public class InimigoController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public GameObject bullet;
    public GameObject tiroPos;
    private float waitShoot = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        Atirando();
    }

    void Atirando()
    {
        waitShoot -= Time.deltaTime;
        if (waitShoot <= 0)
        {
            Instantiate(bullet, tiroPos.transform.position, tiroPos.transform.rotation);
            waitShoot = 1f;
        }

    }
}
