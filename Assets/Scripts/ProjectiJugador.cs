using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectiJugador : MonoBehaviour
{
    private float _vel;
    private Vector2 MaxPantalla;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 10f;
        MaxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1 ));

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PosInicial = transform.position;
        PosInicial = PosInicial + new Vector2(0, 1) * _vel * Time.deltaTime;
        transform.position = PosInicial;
        if (transform.position.y > MaxPantalla.y){
            Destroy(gameObject);
        }

    }
}
