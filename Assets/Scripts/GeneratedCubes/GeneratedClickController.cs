using UnityEngine;

public class GeneratedClickController : MonoBehaviour
{
    public GeneratedCubeController cubeController;
    int layer_mask;

    private void Start()
    {
        layer_mask = LayerMask.GetMask("Cube");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 300.0f, layer_mask))
            { 
                if (hit.transform.gameObject == gameObject)
                    cubeController.HandleClick();
            }
        }
    }
}
