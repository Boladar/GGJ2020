using System;
using UnityEngine;

public class DragableGameObject : MonoBehaviour, IGrabbable {
    private Transform dragPoint;
    private HandController assignedHand;
    
    public void Grab(HandController handController) {
        assignedHand = handController;
    }

    public void Release() {
        throw new NotImplementedException();
    }


    private void Update() {

        if (assignedHand != null) {
            transform.position = assignedHand.GrabbingTransform.position;
        }
        
    }
}