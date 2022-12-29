using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private int damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(){
        EnemyAi script =parent.GetComponent<EnemyAi>();
        script.TakeDamage(damage);
        Debug.Log("takingDmg");
    }
}
