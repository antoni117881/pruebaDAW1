using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenearadorNmeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GeneraNumero", 1f, 2f);
    }

    private void GeneraNumero()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
