using UnityEngine;

public class Magnet1 : MonoBehaviour
{
    public bool north;
    public float power;

    private Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }


    private void OnTriggerStay(Collider other)

    {
        Magnet1 m = other.GetComponent<Magnet1>();
        if (m == null)
            return;
        Vector3 direction = transform.position - m.transform.position;
        direction = direction.normalized;
        Vector3 force = direction /
            (Mathf.Max(a: Vector3.Distance(a: transform.position, b: m.transform.position) *
            Vector3.Distance(a: transform.position, b: m.transform.position), b:0.5f)) * power * m.power;

        if ((north && m.north) || (!north && !m.north))
        {

            RB.AddForce(force);
        }

        else
        {
            RB.AddForce(-force);
                
        }



    }


}
