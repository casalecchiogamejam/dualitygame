using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{

    public float lifetime;
    
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0f)      
            Destroy(gameObject);
    }

    public void ImPublic() {}
}
