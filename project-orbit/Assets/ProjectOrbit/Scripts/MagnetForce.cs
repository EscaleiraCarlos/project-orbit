using UnityEngine;

public class MagnetForce : MonoBehaviour
{
    public MagnetForceType forceType = MagnetForceType.Pull;
    public float power = 10f;

    // Opcional: para ligar/desligar depois
    public bool isActive = true;
}