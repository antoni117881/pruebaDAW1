using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;

   private  Vector2 minPantalla, maxPantalla;

   [SerializeField] private GameObject PrefabProjectil;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        minPantalla = Camera.main.ViewportToWorldPoint( new Vector2(0  , 0) );
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2 (1 , 1 ) );
        float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;
        minPantalla.x = minPantalla.x + meitatMidaImatgeX;// ajusta el borde de la pantalla amb la nau
        maxPantalla.x = maxPantalla.x - meitatMidaImatgeX;
        minPantalla.y = minPantalla.y + meitatMidaImatgeY;
        maxPantalla.y -= meitatMidaImatgeY;
        
       

        
    }

    // Update is called once per frame
    void Update()
    {
        MoureNau();
        DisparaProjectil();
       

    }
    private void DisparaProjectil()
    {
        if (Input.GetKeyDown("space"))
        {
           GameObject Projectil = Instantiate(PrefabProjectil);
            Projectil.transform.position = transform.position;        
        }
    }
    private void MoureNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");

        float direccioIndicadaY = Input.GetAxisRaw("Vertical");

        // Debug.Log("X = " + direccioIndicadaX + "y ="+ direccioIndicadaY);

        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;// posiscio actual del objecte amb el transform.position

        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;

    }
}
