using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject thrust;
    public float thrustBrightness;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        thrust.GetComponent<Renderer>().material.color = new Color(thrustBrightness, thrustBrightness, thrustBrightness);

        anim.Play("Turbulance", 0, Random.value);
        anim.Update(0);
    }
}
