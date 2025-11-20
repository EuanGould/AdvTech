using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class lightButtonBehaviour : MonoBehaviour
{
    [SerializeField] Material on;
    [SerializeField] Material off;
    [SerializeField] float compressed_y_size;
    [SerializeField] int max_charges = 4;
    [SerializeField] Material dead;

    private GameObject light_object;

    private Vector3 default_scale;

    private AudioSource audio_source;

    private float light_timer = 0;

    private bool light_status = false;

    private int charges;

    public void resetCharges()
    {
        charges = max_charges;
        GetComponent<MeshRenderer>().material = off;
    }

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
        default_scale = transform.localScale;
        light_object = transform.GetChild(0).gameObject;
        charges = max_charges;
        GetComponent<MeshRenderer>().material = off;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (charges > 0)
            {
                transform.localScale = new Vector3(1, compressed_y_size, 1);
                audio_source.Play();

                charges --;
                if (charges <= 0)
                {
                    GetComponent<MeshRenderer>().material = dead;
                }
                else
                {
                    light_timer = 0.1f;
                    light_status = true;
                    light_object.GetComponent<MeshRenderer>().material = on;
                    GetComponent<MeshRenderer>().material = on;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.localScale = default_scale;
        }
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
                light_object.GetComponent<MeshRenderer>().material = off;
                GetComponent<MeshRenderer>().material = off;
            }
        }
    }

}
