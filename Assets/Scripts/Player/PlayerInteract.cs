using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [HideInInspector] public static Vector3 screenCentre;

    [SerializeField] private KeyCode interactKey;
    [SerializeField] private float maxDistance;
    private RaycastHit hit;

    private void Awake()
    {
        screenCentre = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
    }
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            TryInteraction();
        }
    }

    private void TryInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.distance < maxDistance)
            {
                IInteractible interactible = hit.collider.GetComponent<IInteractible>();
                if(interactible != null)
                {
                    interactible.Interact();
                }
            }
        }
    }
}
