using UnityEngine;

public class CajaRojo : MonoBehaviour 
{

    public string etiquetaRoja;

    public AudioSource sonidoFuente;
    public AudioClip sonidoCorrecto;

    private void OnTriggerEnter(Collider other) { // para ajustar el trigger con un collider
        if (other.CompareTag(etiquetaRoja)) {
            sonidoFuente.PlayOneShot(sonidoCorrecto);
            Debug.Log("Ha entrado!");
        }
    }
}