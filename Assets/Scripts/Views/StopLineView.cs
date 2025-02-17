using UnityEngine;

public class StopLineView : MonoBehaviour
{

    public StopLineController controller;
    public GameObject greenLight;

    private void Start()
    {
        controller = new StopLineController(this);
        GameManager.Instance.stopLineController = controller;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            TruckView truckView = collision.gameObject.GetComponent<TruckView>();
            truckView.truckController.SetIsReady(true);
            controller.SetIsOccupied(true);
            greenLight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            controller.SetIsOccupied(false);
            greenLight.SetActive(false);
        }
    }
}
