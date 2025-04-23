using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;

    private int pontos;
    private int level = 1;
    private float timeToSpawn = 0f;
    [SerializeField] private float spawnWait = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        spawnWait -= Time.deltaTime;
        if (spawnWait <= timeToSpawn)
        {
            Instantiate(inimigos[0], transform.position, transform.rotation);
            spawnWait = 5f;
            
        }
    }
}
