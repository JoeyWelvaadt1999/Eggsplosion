using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface ICollision : IEventSystemHandler {
	void CollisionEnter (GameObject coll);
}