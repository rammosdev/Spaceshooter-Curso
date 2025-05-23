using UnityEngine;

public class ExplosãoController : MonoBehaviour
{
    //Pegando o audioclipe
    [SerializeField] private AudioClip meuSom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Tocando o audioclipe da explosão apenas se eu estou aparecendo na tela
        if (transform.position.y > -5.5f || transform.position.y < 5f)
        {
            AudioSource.PlayClipAtPoint(meuSom, Vector3.zero);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Morrendo()
    {
        Destroy(gameObject);
    }
}
