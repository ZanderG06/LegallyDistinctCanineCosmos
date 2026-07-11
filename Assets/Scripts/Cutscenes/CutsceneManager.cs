using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject thrust;
    public float thrustBrightness;

    private void Start()
    {
        thrust.GetComponent<Renderer>().material.color = new Color(thrustBrightness, thrustBrightness, thrustBrightness);
    }
}
