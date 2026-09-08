    using UnityEngine;

    public class ContenedorClasificacion : MonoBehaviour
    {
        
        // tag que espera el contenedor
        public string etiquetaCorrecta;

        public Renderer LuzIndicadora;

        public AudioSource fuenteAudio; // bocina de caja
        public AudioClip sonidoAcierto; // sonido de acierto
        public AudioClip sonidoError; // sonido de error

        // cuando interactua con un objeto trigger
        private void OnTriggerEnter(Collider other) {

            /*
            if (fuenteAudio != null && sonidoAcierto != null) {
                fuenteAudio.PlayOneShot(sonidoAcierto);
            }
            */

            /*
            if (fuenteAudio != null && sonidoError != null) {
                fuenteAudio.PlayOneShot(sonidoError);
            }
            */

            // marcamos la reacción
            if (other.CompareTag(etiquetaCorrecta)) {
                LuzIndicadora.material.color = Color.green;
                fuenteAudio.PlayOneShot(sonidoAcierto);
            } else {
                Debug.Log("este dado no va en este contenedor");
                LuzIndicadora.material.color = Color.red;
                fuenteAudio.PlayOneShot(sonidoError);
            }
        }
    }
