using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private KeyCode takeKey, dropKey;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform pivot;
    private GameObject curItem;
    private RaycastHit hit;

    void Update()
    {
        if(Input.GetKeyDown(takeKey))
        {
            TryTaking();
        }
        if(Input.GetKeyDown(dropKey))
        {
            Drop();
        }
        if(Input.GetMouseButton(0))
        {
            if(curItem != null)
            {
                IUsable usable = curItem.GetComponent<IUsable>();
                if(usable != null)
                {
                    usable.Use();
                }
            }
        }
    }

    void TryTaking()
    {
        if (curItem == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(PlayerInteract.screenCentre);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < maxDistance)
                {
                    ITakeable takeable = hit.collider.GetComponent<ITakeable>();
                    if (takeable != null)
                    {
                        takeable.Take();
                        PlaceItemInHand(hit.transform);
                        curItem = hit.collider.gameObject;
                    }
                }
            }
        }
    }

    void Drop()
    {
        if(curItem != null)
        {
            Rigidbody itemRb = curItem.GetComponent<Rigidbody>();
            if (itemRb != null)
            {
                itemRb.isKinematic = false;
            }
            curItem.transform.parent = null;
            curItem = null;
        }
    }

    void PlaceItemInHand(Transform item)
    {
        item.transform.position = pivot.position;
        item.transform.localPosition = Vector3.zero;
        item.parent = pivot;

        Rigidbody itemRb = item.gameObject.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.isKinematic = true;
        }
    }

}
