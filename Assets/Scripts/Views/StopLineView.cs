using UnityEngine;

public class StopLineView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            TruckView truckView = collision.gameObject.GetComponent<TruckView>();
            truckView.truckController.SetIsReady(true);
        }
    }
}
