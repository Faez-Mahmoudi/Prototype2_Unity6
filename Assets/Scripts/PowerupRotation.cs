using UnityEngine;

public class PowerupRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 25;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
