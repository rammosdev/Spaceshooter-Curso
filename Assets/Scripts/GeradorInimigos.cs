using Unity.VisualScripting;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;

    [SerializeField]private int pontos;
    [SerializeField]private int level = 1;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float spawnWait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();
    }

    private void GeraInimigos()
    {
            //Timer
            spawnWait -= Time.deltaTime;
            if (spawnWait <= 0f)
            {
                int quantidade = level * 4;
                int qtdInimigo = 0;
                while (qtdInimigo < quantidade)
                {
                    GameObject inimigoCriado;

                    float chance = Random.Range(0f, level);

                    if (chance > 2f)
                    {
                        inimigoCriado = inimigos[1];
                    }
                    else
                    {
                        inimigoCriado = inimigos[0];
                    }

                    //Criando um inimigo
                    Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);
                    Instantiate(inimigoCriado, posicao, transform.rotation);
                    qtdInimigo++;
                    spawnWait = timeToSpawn;
            }
        }
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos;
    }
}
