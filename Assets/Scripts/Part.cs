using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{

    float time_left;
    public List<MeshRenderer> rend;

    List<Material> mats = new List<Material>();
    public float max_impulse = 1000f;

    // Renderer rend;

    void Start()
    {
        time_left = Random.Range(3f, 5f);
        var force = max_impulse * new Vector3(
            Random.Range(-1, 1),
            Random.Range(-1, 1),
            Random.Range(-1, 1)
        );
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        // foreach (var )
    }

    void Update()
    {
        time_left -= Time.deltaTime;
        foreach (var r in rend)
            r.material.SetFloat("PresenceFactor", time_left);
        
        if (time_left < 0f)
            Destroy(gameObject);
    }
}
