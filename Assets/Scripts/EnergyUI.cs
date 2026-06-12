using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    private RectTransform rectTransform;
    private ServiceHub serviceHub;

    private float width;
    private float height;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        serviceHub = ServiceHub.Instance;

        width = rectTransform.sizeDelta.x;
        height = rectTransform.sizeDelta.y;
    }

    private void Update()
    {
        float newWidth = (ServiceHub.Instance.PlaneController.energy / 100) * width;
        rectTransform.sizeDelta = new Vector2(newWidth, height);
    }
}
