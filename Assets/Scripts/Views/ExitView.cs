using UnityEngine;

public class ExitView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            TruckView truckView = collision.gameObject.GetComponent<TruckView>();
            truckView.truckController.SetIsReady(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            TruckView truckView = collision.gameObject.GetComponent<TruckView>();
            if (truckView.truckController.IsJobDone())
            {
                Destroy(collision.gameObject);
                GameManager.Instance.playerController.ChangePlayerScore(50);
            }
            else
            {
                Destroy(collision.gameObject);
                GameManager.Instance.playerController.ChangePlayerScore(-50);
            }
        }
    }
}
