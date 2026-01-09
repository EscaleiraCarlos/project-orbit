using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagneticBall : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        MagnetForce magnet = other.GetComponent<MagnetForce>();
        if (magnet == null || !magnet.isActive)
            return;

        Vector3 direction = magnet.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance < 0.1f)
            return;

        direction.Normalize();

        float forceStrength = magnet.power / Mathf.Max(distance * distance, 0.5f);

        Vector3 force;

        if (magnet.forceType == MagnetForceType.Pull)
        {
            force = direction * forceStrength;
        }
        else // Push
        {
            force = -direction * forceStrength;
        }

        rb.AddForce(force, ForceMode.Force);
    }
}
