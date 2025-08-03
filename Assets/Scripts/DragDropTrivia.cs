using UnityEngine;

public class DragDropTrivia : MonoBehaviour {
    Vector3 offset;
    Camera cam;

    private Rigidbody rb;  // Variable para el Rigidbody

    void Start(){
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();  // Obtener el Rigidbody
    }

    void OnMouseDown(){
        // Permitir mover el cubo si no ha sido colocado
        if (!GameManagerTrivia.instance.cuboPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                offset = transform.position - ray.GetPoint(enter);
        }
    }

    void OnMouseDrag(){
        // Permitir mover el cubo mientras lo arrastra
        if (!GameManagerTrivia.instance.cuboPlaced) {
            var plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float enter))
                transform.position = ray.GetPoint(enter) + offset;
        }
    }

    void OnMouseUp(){
        // Una vez que el cubo ha sido colocado en la opción correcta
        if (gameObject.CompareTag("Cubo") && GameManagerTrivia.instance.cuboPlaced) {
            this.enabled = false;  // Deshabilita el script DragDrop para el cubo
            GetComponent<Collider>().enabled = false;  // Deshabilita el collider para evitar interacciones
            rb.isKinematic = true;  // Congela la física
            rb.freezeRotation = true;  // Congela la rotación
        }
    }
}
