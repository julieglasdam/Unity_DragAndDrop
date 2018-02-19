using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandlerScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	public int rectPosX;
	public int rectPosY;
	public int rectWidth;
	public int rectHeight;

	Vector3 startPosition;     // Start position of the gameobject 
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

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;                   		  // Idk why
		if (transform.parent == startParent) {            // If the parent has changed
			transform.position = Input.mousePosition;     // Set item to new position, where mouse is
		}
	}

	#endregion


	// Check if object is inside the correct area. If it is: place block, if it's not: bounce back to start position
/*	private void CollisionDetectionWalls() {
	}

	private void CollisionDetectionObjects() {
	
	}*/

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "BuildArea")
			Debug.Log ("Colling with box");

	}


}
