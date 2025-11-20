using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShownNumber : MonoBehaviour
{
    private TextMeshPro text_box;
    private int numbers_generated = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        text_box = GetComponent<TextMeshPro>();
    }

    public void Reset()
    {
        Random.InitState(numbers_generated);
        numbers_generated++;
        text_box.text = Mathf.Floor(Random.value * 1000).ToString("000");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
