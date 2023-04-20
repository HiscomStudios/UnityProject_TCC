using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyPlus : MonoBehaviour
{
    protected Rigidbody rb;
    
    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce(float force)
    {
        rb.velocity = Vector3.zero;
        rb.gameObject.transform.localEulerAngles = Vector3.zero;
        rb.AddForce(transform.localScale * force, ForceMode.Impulse);
    }
}