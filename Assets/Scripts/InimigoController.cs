using UnityEngine;

public class InimigoController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public GameObject bullet;
    public GameObject tiroPos;
    private float waitShoot = 1f;
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -speed);
        waitShoot = Random.Range(0.5f, 2f);
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Atirando();


    }

    void Atirando()
    {

        bool visivel = sprite.isVisible;
        Debug.Log(visivel);
        if (visivel == true)
        {
            //Diminuindo a espera pelo deltaTime
            waitShoot -= Time.deltaTime;
            if (waitShoot <= 0)
            {
                Instantiate(bullet, tiroPos.transform.position, tiroPos.transform.rotation);
                waitShoot = Random.Range(1.5f, 2f);
            }
        }


    }
}
