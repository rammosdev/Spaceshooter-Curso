using System;
using UnityEngine;

public class BossController : InimigoPai
{
    [SerializeField] private string estado = "estado1";
    private Rigidbody2D rb;
    [SerializeField] private bool direita;
    [SerializeField] private float limiteH;

    [Header("Tiros")]
    [SerializeField] private Transform posicaoTiro1;
    [SerializeField] private Transform posicaoTiro2;
    [SerializeField] private Transform posicaoTiro3;
    [SerializeField] private GameObject tiro1;
    [SerializeField] private GameObject tiro2;
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
                Tiro1();
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

    private void Tiro1()
    {
        waitShoot -= Time.deltaTime;
        if (waitShoot <= 0)
        {
            GameObject tiroUm = Instantiate(tiro1, posicaoTiro1.position, transform.rotation);
            GameObject tiroDois = Instantiate(tiro1, posicaoTiro2.position, transform.rotation);

            tiroUm.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
            tiroDois.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
            waitShoot = 1;
        }

    }

    private void Tiro2()
    {

    }
}
