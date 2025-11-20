using UnityEngine;
using UnityEngine.Audio;

public class InputNumberBehaviour : MonoBehaviour
{
    [SerializeField] private int adder;

    [SerializeField] private float compressed_y_size;

    [SerializeField] private InputNumber input_number;

    private Vector3 default_scale;


    private void Awake()
    {
        default_scale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector3(1, compressed_y_size, 1);
            input_number.Increment(adder);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.localScale = default_scale;
        }
    }
}
