using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject camadaPorta;
    public float tempoParaFechar = 5f;

    void Start()
    {
        
    }

    Coroutine rotina = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && rotina == null) 
            rotina = StartCoroutine(abrirPortas());
    }

    IEnumerator abrirPortas(){
        camadaPorta.SetActive(false);
        yield return new WaitForSeconds(tempoParaFechar);
        camadaPorta.SetActive(true);
        rotina = null;
    }
}
