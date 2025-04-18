using Unity.VisualScripting;
using UnityEngine;

public class InimigoController : InimigoPai
{
    Rigidbody2D rb;
    [Header("Tiro")]
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
        if (visivel == true)
        {
            //Diminuindo a espera pelo deltaTime
            waitShoot -= Time.deltaTime;
            if (waitShoot <= 0)
            {
                Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
                waitShoot = Random.Range(1.5f, 2f);
            }
        }


    }

}
