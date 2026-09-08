using UnityEngine;

public class CrearDado : MonoBehaviour
{
    
    public GameObject prefab;
    public Transform spawn;

    public void instanciarObjeto() {
        if (prefab != null && spawn != null) {
            Instantiate(prefab, spawn.position, spawn.rotation);
        }
    }    
    
}
