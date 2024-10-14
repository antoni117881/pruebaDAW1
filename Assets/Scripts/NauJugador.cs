using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




/*
 * Repas 
 * que hem vist 
 *      - Crear objectes a la escenea 
 *      - crear Emty Object utilizat per el generador de numeros 
 *      -Prefabs  crear objectes cuan el joc sesta executant    
 *          - crear un prefab es arastrarlo a la carpeta prefabs
 *          -per crear un prefab a l'ecena en execucio amb el metoda Instantiate(nom del prefab)
 *              -Variable del prefab de tipus GameObject 
 *      -Trobar posisio objecta actual transform.position
 *      -Trbar marges pantalla amb el camera.main.viewportToWorldPoint()
 *      -[serializeField] per fer que una variable private de la clase es mostri a l'editor de unity 
 *      - utilitzar un sprite com si fos mes d'una (contenit subimatges)
 *          -selecionem srite amb l'opcio sprite mode cambie a multiple y apliquem 
 *          - cliquelm al boto sprite editor per editar el sprite y ferlo mes d'un 
 *      -Destroir objecte actual destroy(GameObject)
 *      -crida metode al cap e X segons  Invoke (nomMetode , Xf segons);
 *     -cridar u metode al cap de X segons i cada y Segons  InvokeRepeatig (nommetode ,xf ,yf)
 *     -com aturar un  InvokeRepeating CanselInvoke(Nome metode)
 *     -com detectar que un objecta toca un altre 
 *          - afegir als objectes ue volem que es toquin els components BoxCollider2D i Rigidbody2D
 *          -en BoxColider2D sa d'activar el box de  IsTriger
 *          -En Rigidbody2D GravityScale posarlo a 0 
 */
public class NauJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla, maxPantalla;

   [SerializeField] private GameObject prefabProjectil;
   [SerializeField] private GameObject prefabExplosio;
   [SerializeField] private TMPro.TextMeshProUGUI componentTextVides;

    private int videsNau;

    

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;


        minPantalla.x = minPantalla.x + meitatMidaImatgeX;
        maxPantalla.x = maxPantalla.x - meitatMidaImatgeX;
        minPantalla.y += meitatMidaImatgeY;
        maxPantalla.y -= meitatMidaImatgeY;

        videsNau = 3;
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
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }
    }

    private void MoureNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;// transform.position: pos actual de la nau.
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;
        //Debug.Log(Time.deltaTime);

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }   

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if(objecteTocat.tag == "Numero")
        {
            videsNau--;
            componentTextVides.text = "vides " + videsNau.ToString();
            if (videsNau <= 0)
            {
                GameObject explosio = Instantiate(prefabExplosio);
                explosio.transform.position = transform.position;
                SceneManager.LoadScene("PantallaResultats");    
                Destroy(gameObject);
            }
          
        }
    }
}
