using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHandler : MonoBehaviour {

    private bool cuboPlaced = false, cilindroPlaced = false, conoPlaced = false;

    public TextMeshProUGUI feedbackText; // Asigna un Text UI

    private void Update()
    {
        cuboPlaced = GameManager.instance.cuboPlaced;
        cilindroPlaced = GameManager.instance.cilindroPlaced;
        conoPlaced = GameManager.instance.conoPlaced;
    }

    void OnTriggerEnter(Collider other) {
    // Si el objeto es un cubo y el objetivo es un Goal_Cubo, lo coloca encima
    if (other.CompareTag("Cubo") && gameObject.CompareTag("Goal_Cubo") && !cuboPlaced)
    {
        feedbackText.text = "¡Cubo colocado correctamente!";
        GameManager.instance.ObjectPlaced("Cubo");

        // Coloca el cubo encima del edificio
        other.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); // Ajusta la altura según sea necesario

        cuboPlaced = true; // Marcar como colocado
    }
    else if (other.CompareTag("Cilindro") && gameObject.CompareTag("Goal_Cilindro") && !cilindroPlaced)
    {
        feedbackText.text = "¡Cilindro colocado correctamente!";
        GameManager.instance.ObjectPlaced("Cilindro");

        // Coloca el cilindro encima del edificio
        other.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); // Ajusta la altura según sea necesario

        cilindroPlaced = true;
    }
    else if (other.CompareTag("Cono") && gameObject.CompareTag("Goal_Cono") && !conoPlaced)
    {
        feedbackText.text = "¡Cono colocado correctamente!";
        GameManager.instance.ObjectPlaced("Cono");

        // Coloca el cono encima del edificio
        other.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); // Ajusta la altura según sea necesario

        conoPlaced = true;
    }
    else {
        feedbackText.text = "Error: lugar incorrecto";
    }
}
}
