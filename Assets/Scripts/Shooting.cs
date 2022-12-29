using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera cam;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private float distance = 10f;
    private PlayerInputManager inputManager;
    private Animator animator;

    private bool isShooting;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        inputManager = GetComponent<PlayerInputManager>();
        animator = gun.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (inputManager.onFoot.Shoot.triggered)
        {

            ShootingAnimPlayer();


            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
               DamageReceiver received = hitInfo.collider.GetComponent<DamageReceiver>();
                received.TakeDamage();
            }

        }



    }
    void ShootingAnimPlayer()
    {
        isShooting = true;
        animator.Play("shoot");
    }

}
