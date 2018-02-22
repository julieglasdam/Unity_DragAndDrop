using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandlerScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;


	Vector3 startPosition;     
	Transform startParent;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;                   // Gameobject currently used
		startPosition = transform.position;              // Where the item is dragged back to
		startParent = transform.parent;		  			 // To determine if the object has been dragged to a new spot (If it has a new parent)
	}

	#endregion

	#region IDragHandler implementation
	// Change items position when the user is dragging it
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation
	// When user lets go of object, make it bounce back
	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;                   		  // Idk why
		if (transform.parent == startParent) {            // If the parent has changed
			transform.position = startPosition;     	  // Make item bounce back 
		}
	}

	#endregion



	// Check for collision with the box
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("BuildArea")) {
			gameObject.SetActive (false);
		}
	}


}
