using UnityEngine;
 // <- permite leer el XR
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TeletransportadorPortal : MonoBehaviour
{
    public AudioSource sonidoFuente;
    public AudioClip sonidoTransportacion;
    public Transform sensorDestino; // punto de destino
    private bool listoTransportar = true; // evita que se transporte infinitamente

    private void OnTriggerEnter(Collider other) {
        // 1. Validación de seguridad: si no está listo o no hay destino, no hacemos nada
        if (!listoTransportar || sensorDestino == null) {
            return;
        }

        // Si el objeto tiene un componente Grab Interactable y está seleccionado
        XRGrabInteractable grabable = other.GetComponent<XRGrabInteractable>();
        if (grabable != null && grabable.isSelected) {
            return; 
        }

        // 2. Avisar al portal de destino que se desactive temporalmente
        TeletransportadorPortal scriptDestino = sensorDestino.GetComponent<TeletransportadorPortal>();
        if (scriptDestino != null) {
            scriptDestino.DesactivarTemporalmente();
        }

        // 3. Reproducir sonido si está configurado
        if (sonidoFuente != null && sonidoTransportacion != null) {
            sonidoFuente.PlayOneShot(sonidoTransportacion);
        }

         // 4. Lógica de teletransportación separada (Jugador vs Objetos)
        if (other.CompareTag("Player")) {
            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null) cc.enabled = false;
            other.transform.position = sensorDestino.position + sensorDestino.forward * 2.0f;
            if (cc != null) cc.enabled = true;
        } 
        else {
            // Objetos normales (como los dados)
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null) {
                // Detenemos en seco su velocidad física y rotación para evitar que salga disparado
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Lo movemos al destino (le sumamos un pequeño empuje hacia adelante 
            // para que no aparezca exactamente encima del marco del portal de salida)
            other.transform.position = sensorDestino.position + sensorDestino.forward * 2.0f;
        }


    }

    private void OnTriggerExit(Collider other) {
        listoTransportar = true;
    }

    public void DesactivarTemporalmente() {
        listoTransportar = false;
    }
}