using System.Collections;
using System.Collections.Generic;
//using System.Media;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damageAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.DecreaseHealth(damageAmount);
        }
    }
}
