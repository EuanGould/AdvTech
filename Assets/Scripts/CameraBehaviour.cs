using UnityEngine;
//using Unity.Netcode;
using Mirror;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NetworkClient.localPlayer != null)
        {
            if (NetworkClient.localPlayer.gameObject != null)
            {
                transform.position = new Vector3(
                    NetworkClient.localPlayer.gameObject.transform.position.x,
                    transform.position.y,
                    NetworkClient.localPlayer.gameObject.transform.position.z
                );
            }
        }


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
