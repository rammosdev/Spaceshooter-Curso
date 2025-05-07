using System;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private string estado = "estado1";
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [SerializeField] private bool direita;
    [SerializeField] private float limiteH;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case "estado1":
                Estado1();
                break;
            case "estado2":
                Debug.Log("Estou no segundo estado");
                break;
            case "estado3":
                Debug.Log("Estou no terceiro estado");
                break;
        }
    }

    private void Estado1()
    {
        //Indo para direita e esquerda
        

        if (direita)
        {
            rb.linearVelocity = new Vector2(speed, 0f);
        }else
        {
            rb.linearVelocity = new Vector2(-speed, 0f);
        }

        if (transform.position.x >= limiteH)
        {
            direita = false;
        }else if (transform.position.x <= -limiteH)
        {
            direita = true;
        }
    }
}
