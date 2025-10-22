using UnityEngine;

public class bridgeBehaviour : MonoBehaviour
{
    private int stage = 0;
    [SerializeField] private float offset = 0f;
    [SerializeField] private float increment = 120f;
    [SerializeField] private int stages = 3;

    public void Activate()
    {
        stage++;
        stage %= stages;

        transform.eulerAngles = new Vector3 (0.0f, increment * stage + offset, 0.0f);
    }
}
