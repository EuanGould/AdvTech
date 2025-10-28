using UnityEngine;

public class floorButtonBehaviour : MonoBehaviour
{
    [SerializeField] bridgeBehaviour bridge_script;

    [SerializeField] Material on;
    [SerializeField] Material off;

    private Vector3 default_scale;

    private AudioSource audio_source;

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
        default_scale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = on;
            bridge_script.Activate();
            audio_source.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = off;
            bridge_script.Activate();
            audio_source.Play();
        }
    }

}
