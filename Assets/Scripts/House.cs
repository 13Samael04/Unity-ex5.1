using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _signaling.Signal(_signaling.GetMaxVolume());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _signaling.Signal(_signaling.GetMinVolume());
    }
}
