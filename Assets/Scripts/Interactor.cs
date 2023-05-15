using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IInteractable
{
    public void Interac();
}
public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactionrange;




    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if(Physics.Raycast(r,out RaycastHit hitInfo, interactionrange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interacobj))
                {
                    interacobj.Interac();
                }
            }
        }
    }


}
