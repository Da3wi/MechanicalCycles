using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Away : MonoBehaviour
{
    private Quaternion originalLR;


    private void Start()
    {
        originalLR = transform.rotation;
    }


    void Update()
    {
        UpdateSway();
    }


    private void UpdateSway()
    {
        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse y");

        Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * 1.45f, Vector3.up);
        Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(t_yLookInput * 1.45f, Vector3.right);
        Quaternion t_targetRotation = originalLR * t_xAngleAdjustment * t_yAngleAdjustment;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targetRotation, Time.deltaTime * 3f);
    }
}
