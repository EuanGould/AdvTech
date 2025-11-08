using NUnit.Framework;
using System.Collections.Generic;
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
            if (GetComponent<MeshRenderer>().material == off)
            {
                bridge_script.Activate();
                audio_source.Play();
            }


            GetComponent<MeshRenderer>().material = on;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collider[] all_overlappers;
            BoxCollider box_collider = GetComponent<BoxCollider>();

            all_overlappers = Physics.OverlapBox(transform.position + box_collider.center, transform.localScale / 2);

            bool player_still_present = false;

            foreach (Collider col in all_overlappers)
            {
                if (col.gameObject.CompareTag("Player"))
                {
                    player_still_present = true;
                }
            }
            
            if (!player_still_present)
            {
                GetComponent<MeshRenderer>().material = off;
                bridge_script.Activate();
                audio_source.Play();
            }

        }




    }

}
