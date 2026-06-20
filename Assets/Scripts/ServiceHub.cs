using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private PlaneController planeController;
    [SerializeField] private BulletManager bulletManager;
    [SerializeField] private UIManager uiManager;

    public PlaneController PlaneController => planeController;
    public BulletManager BulletManager => bulletManager;
    public UIManager UIManager => uiManager;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}