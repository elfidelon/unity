using UnityEngine;
using UnityEngine.UI;

public class MetaTrigger : MonoBehaviour
{
    public string tagJugador = "Player";
    public Text textoUI;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagJugador)) return;

        Debug.Log("¡Meta alcanzada!");

        if (textoUI != null)
        {
            textoUI.text = "¡Meta alcanzada!";
        }
    }
}
