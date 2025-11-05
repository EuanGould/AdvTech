using UnityEngine;
using Unity.Netcode;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (NetworkManager.Singleton.LocalClient != null)
        //{
        //    if (NetworkManager.Singleton.LocalClient.PlayerObject != null)
        //    {
        //        transform.position = new Vector3(
        //            NetworkManager.Singleton.LocalClient.PlayerObject.transform.position.x,
        //            transform.position.y,
        //            NetworkManager.Singleton.LocalClient.PlayerObject.transform.position.z
        //        );
        //    }
        //}
    }
}
