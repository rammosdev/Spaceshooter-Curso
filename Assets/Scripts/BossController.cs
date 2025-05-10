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
    [SerializeField] private float delayTiro = 1f;
    [SerializeField] private float waitShoot2;
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
                Estado2();
                break;
            case "estado3":
                Estado3();
                break;
        }
    }

    private void Estado1()
    {
        waitShoot -= Time.deltaTime;
        if (waitShoot < 0)
        {
            Tiro1();
            waitShoot = delayTiro;
        }
        //Indo para direita e esquerda
        if (direita)
        {
            rb.linearVelocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0f);
        }

        if (transform.position.x >= limiteH)
        {
            direita = false;
        }
        else if (transform.position.x <= -limiteH)
        {
            direita = true;
        }

    }

    private void Tiro1()
    {
        GameObject tiroUm = Instantiate(tiro1, posicaoTiro1.position, transform.rotation);
        GameObject tiroDois = Instantiate(tiro1, posicaoTiro2.position, transform.rotation);

        tiroUm.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
        tiroDois.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
    }

    private void Estado2()
    {
        waitShoot -= Time.deltaTime;
        if (waitShoot <= 0)
        {
            Tiro2();
            waitShoot = delayTiro / 2;
        }
    }
    private void Tiro2()
    {
        //Encontrando o player na cena
        var player = FindFirstObjectByType<PlayerController>();
        if (player)
        {
            GameObject tiro = Instantiate(tiro2, posicaoTiro3.position, transform.rotation);
            //Encontrando o valor da direção
            Vector2 direcao = player.transform.position - tiro.transform.position;
            direcao.Normalize();
            //Dando a direção do tiro
            tiro.GetComponent<Rigidbody2D>().linearVelocity = direcao * -bulletSpeed;
            //Dando o ângulo certo do tiro
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            //Passando o angulo
            tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);
            waitShoot = 0.5f;
        }
    }

    private void Estado3()
    {
        //Tiro1
        waitShoot -= Time.deltaTime;
        if (waitShoot < 0)
        {
            Tiro1();
            waitShoot = delayTiro;
        }

        //Tiro2
        waitShoot2 -= Time.deltaTime;
        if (waitShoot2 <= 0)
        {
            Tiro2();
            waitShoot2 = delayTiro;
        }

    }
}
