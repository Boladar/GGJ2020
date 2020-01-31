using System;
using UnityEngine;

public class DragableGameObject : MonoBehaviour, IGrabbable {
    private Transform dragPoint;
    private HandController assignedHand;
    
    public void Grab(HandController handController) {
        assignedHand = handController;
    }

    public void Release() {
        assignedHand = null;
    }
    
    private void Update() {

        if (assignedHand != null) {
            dragPoint.position = assignedHand.transform.position;
        }
        
    }
}