using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float shootForce;
    public Rigidbody rigidbody;
    public float fuseTime = 5;
    public float explosionTime = 1f;
    public float explosionForce;
    public float explosionRadius;
    public GameObject particals;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }

    // Update is called once per frame
    void Update()
    {
        fuseTime -= Time.deltaTime;
        if (fuseTime <= 0)
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null && rb.tag != "Player")
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0, ForceMode.Impulse);
                }
            }
            explosionTime -= Time.deltaTime;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<MeshRenderer>().enabled = false;
            if (GetComponentInChildren<ParticleSystem>() == null)
            {
                Instantiate(particals, transform);
            }
            if (explosionTime <= 0)
            {
                Destroy(this.gameObject);

            }
        }
    }
}
