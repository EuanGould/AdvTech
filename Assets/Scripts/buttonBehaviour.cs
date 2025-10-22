using UnityEngine;

public class buttonBehaviour : MonoBehaviour
{
    [SerializeField] float uncompressed_y_size = 0.2f;
    [SerializeField] float compressed_y_size = 0.1f;
    [SerializeField] bridgeBehaviour bridge_script;

    private AudioSource audio_source;

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector3(1, compressed_y_size, 1);
            bridge_script.Activate();
            audio_source.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector3(1, uncompressed_y_size, 1);
        }
    }

}
