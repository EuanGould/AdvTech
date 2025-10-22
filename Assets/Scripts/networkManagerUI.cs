using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class networkManagerUI : MonoBehaviour
{
    [SerializeField] private Button host_button;
    [SerializeField] private Button client_button;

    private void Awake()
    {
        host_button.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        client_button.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
}
