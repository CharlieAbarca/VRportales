using UnityEngine;

public class CajaAzul: MonoBehaviour
{

    public string etiquetaAzul; 
    public AudioSource fuenteAudio;
    public AudioClip sonidoCorrecto;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(etiquetaAzul)) {
            fuenteAudio.PlayOneShot(sonidoCorrecto);
        }
    }

}
