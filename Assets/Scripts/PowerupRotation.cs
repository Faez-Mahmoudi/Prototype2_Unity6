using UnityEngine;

public class PowerupRotation : MonoBehaviour
{
    private float rotationSpeed = 15;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
