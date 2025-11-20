using UnityEngine;
using UnityEngine.Audio;

public class BridgeFloorButton : MonoBehaviour
{
    [SerializeField] Material on;
    [SerializeField] Material off;

    [SerializeField] lightButtonBehaviour[] light_buttons;
    [SerializeField] ShownNumber shown_number;

    private float light_timer = 0;

    private bool light_status = false;

    private void resetAll()
    {
        foreach (lightButtonBehaviour light_button in light_buttons)
        {
            light_button.resetCharges();
            shown_number.Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        resetAll();
        light_status = true;
        light_timer = 0.2f;
        GetComponent<MeshRenderer>().material = on;
    }

    private void OnTriggerExit(Collider other)
    {
        resetAll();
        light_status = true;
        light_timer = 0.2f;
        GetComponent<MeshRenderer>().material = on;
    }

    private void FixedUpdate()
    {
        if (light_status)
        {
            if (light_timer > 0)
            {
                light_timer -= Time.fixedDeltaTime;
            }
            else
            {
                light_status = false;
                GetComponent<MeshRenderer>().material = off;
            }
        }
    }
}
