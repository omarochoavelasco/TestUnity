using UnityEngine;

public class DragDrop : MonoBehaviour {
    Vector3 offset;
    Camera cam;

    private Rigidbody rb; // Variable para el Rigidbody

    void Start(){
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();  // Obtener el Rigidbody
    }

    void OnMouseDown(){
        // Verificamos si el objeto ya fue colocado
        if (gameObject.CompareTag("Cubo") && !GameManager.instance.cuboPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                offset = transform.position - ray.GetPoint(enter);
        }
        else if (gameObject.CompareTag("Cilindro") && !GameManager.instance.cilindroPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                offset = transform.position - ray.GetPoint(enter);
        }
        else if (gameObject.CompareTag("Cono") && !GameManager.instance.conoPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                offset = transform.position - ray.GetPoint(enter);
        }
    }

    void OnMouseDrag(){
        // Solo permitir mover si no ha sido colocado
        if (gameObject.CompareTag("Cubo") && !GameManager.instance.cuboPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                transform.position = ray.GetPoint(enter) + offset;
        }
        else if (gameObject.CompareTag("Cilindro") && !GameManager.instance.cilindroPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                transform.position = ray.GetPoint(enter) + offset;
        }
        else if (gameObject.CompareTag("Cono") && !GameManager.instance.conoPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                transform.position = ray.GetPoint(enter) + offset;
        }
    }

    void OnMouseUp(){
        // Una vez que el objeto haya sido colocado, ya no se puede mover más
        if (gameObject.CompareTag("Cubo") && GameManager.instance.cuboPlaced) {
            this.enabled = false;  // Deshabilita el script DragDrop para el cubo
            GetComponent<Collider>().enabled = false;  // Deshabilita el collider para evitar interacciones

            // Congelar posición y rotación del Rigidbody
            rb.isKinematic = true;  // Desactiva la física
            rb.freezeRotation = true;  // Congela la rotación
        }
        else if (gameObject.CompareTag("Cilindro") && GameManager.instance.cilindroPlaced) {
            this.enabled = false;
            GetComponent<Collider>().enabled = false;

            // Congelar posición y rotación del Rigidbody
            rb.isKinematic = true;
            rb.freezeRotation = true;
        }
        else if (gameObject.CompareTag("Cono") && GameManager.instance.conoPlaced) {
            this.enabled = false;
            GetComponent<Collider>().enabled = false;

            // Congelar posición y rotación del Rigidbody
            rb.isKinematic = true;
            rb.freezeRotation = true;
        }
    }
}
