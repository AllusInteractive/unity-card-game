using UnityEngine;
using System.Collections;

/// <summary>
/// This script should be attached to the card game object to display the card's rotation correctly.
/// </summary>

[ExecuteInEditMode]
public class CardRotation : MonoBehaviour {

    public RectTransform CardFront;
    public RectTransform CardBack;
    public Transform targetFacePoint;
    public Collider col;
    private bool showingBack = false;

	void Update () 
    {
        // Raycast from Camera to a target point on the face of the card
        // If it passes through the card's collider, we should show the back of the card
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position, 
                                  direction: (-Camera.main.transform.position + targetFacePoint.position).normalized, 
            maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude) ;
        bool passedThroughColliderOnCard = false;
        foreach (RaycastHit h in hits)
        {
            if (h.collider == col)
                passedThroughColliderOnCard = true;
        }
        
        if (passedThroughColliderOnCard != showingBack)
        {
            showingBack = passedThroughColliderOnCard;
            if (showingBack)
            {
                // show the card back
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
            else
            {
                // show the card front
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }

        }

	}
}
