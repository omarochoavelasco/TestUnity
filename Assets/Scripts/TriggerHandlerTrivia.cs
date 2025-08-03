using TMPro;
using UnityEngine;

public class TriggerHandlerTrivia : MonoBehaviour {

    private bool cuboPlaced = false;
    public TextMeshProUGUI feedbackText;  // Asigna un Text UI para mostrar el resultado

    void OnTriggerEnter(Collider other) {
        // Cuando el cubo entra en el área del edificio
        if (other.CompareTag("Cubo") && gameObject.CompareTag("Goal_Opcion1") && !cuboPlaced) {
            feedbackText.text = "¡Cubo colocado en Opción 1!";
            GameManagerTrivia.instance.ObjectPlaced("Cubo", "Opcion1");
            cuboPlaced = true;
        }
        else if (other.CompareTag("Cubo") && gameObject.CompareTag("Goal_Opcion2") && !cuboPlaced) {
            feedbackText.text = "¡Cubo colocado en Opción 2!";
            GameManagerTrivia.instance.ObjectPlaced("Cubo", "Opcion2");
            cuboPlaced = true;
        }
        else if (other.CompareTag("Cubo") && gameObject.CompareTag("Goal_Opcion3") && !cuboPlaced) {
            feedbackText.text = "¡Cubo colocado en Opción 3!";
            GameManagerTrivia.instance.ObjectPlaced("Cubo", "Opcion3");
            cuboPlaced = true;
        }
        else if (other.CompareTag("Cubo") && gameObject.CompareTag("Goal_Opcion4") && !cuboPlaced) {
            feedbackText.text = "¡Cubo colocado en Opción 4!";
            GameManagerTrivia.instance.ObjectPlaced("Cubo", "Opcion4");
            cuboPlaced = true;
        }
        else {
            feedbackText.text = "Error: lugar incorrecto";
        }
    }

    // Este método se encargará de resetear las posiciones de los objetos si es necesario
    public void ResetObjectPositions() {
        cuboPlaced = false;
    }
}
