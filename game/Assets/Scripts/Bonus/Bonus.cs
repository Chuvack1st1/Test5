using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [Range(-1, 3)]
    public int bonusCount = 0;

    private Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var meaponManager = other.gameObject.GetComponentInChildren<MeaponManager>();
        if (meaponManager != null)
        {
            meaponManager.AddBonus(bonusCount);

            Destroy(gameObject);
        }
    }
}
