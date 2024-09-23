using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");

        float direccioIndicadaY = Input.GetAxisRaw("Vertical");

        // Debug.Log("X = " + direccioIndicadaX + "y ="+ direccioIndicadaY);

        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY);

        Vector2 novaPos = transform.position;// posiscio actual del objecte amb el transform.position

        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime ;
        transform.position = novaPos;
       

    }
}
