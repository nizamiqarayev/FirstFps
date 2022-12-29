using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUi playerUI;

    [SerializeField]
    private int playerHealth;


    private PlayerInputManager inputManager;
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUi>();
        inputManager = GetComponent<PlayerInputManager>();
        playerUI.UpdateHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > 0)
        {
            playerUI.UpdateText(string.Empty);

        }
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            // Debug.Log(hitInfo.collider);
            if (hitInfo.collider.GetComponent<Interactable>() != null && playerHealth > 0)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                // Debug.Log("working" + interactable.promptMessage);
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interaction.triggered)
                {
                    // Debug.Log(playerInput.OnFootMovement.Interaction.triggered);

                    interactable.BaseInteract();

                }
            }
        }

        if (inputManager.onFoot.Interaction.triggered && playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Time.timeScale = 1;

        }
    }

    public void TakeDamage()
    {
        playerHealth -= 5;

        playerUI.UpdateHealth(playerHealth);
        if (playerHealth <= 0)
        {
            ResetGame();

        }
    }

    public void ResetGame()
    {
        playerUI.Death();
    }
}
