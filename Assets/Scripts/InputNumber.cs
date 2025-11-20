using TMPro;
using UnityEngine;

public class InputNumber : MonoBehaviour
{
    [SerializeField] private GameObject shown_number;
    [SerializeField] private GameObject victory_bridge;

    private int displayed_value = 0;


    public void Increment(int amount)
    {
        if (Mathf.Floor(((displayed_value + amount) % (amount * 10)) / amount) != 0)
        {
            displayed_value += amount;

        }
        else
        {
            displayed_value -= amount * 9;
        }

        displayed_value %= 1000;
        GetComponent<TextMeshPro>().text = displayed_value.ToString("000");

        if (GetComponent<TextMeshPro>().text == shown_number.GetComponent<TextMeshPro>().text)
        {
            victory_bridge.SetActive(true);
        }
    }

    private void Awake()
    {
        
    }
}
