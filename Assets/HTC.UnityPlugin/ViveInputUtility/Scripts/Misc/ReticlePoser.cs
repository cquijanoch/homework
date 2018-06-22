//========= Copyright 2016-2018, HTC Corporation. All rights reserved. ===========

using HTC.UnityPlugin.Pointer3D;
using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.Serialization;

public class ReticlePoser : MonoBehaviour
{
    public interface IMaterialChanger
    {
        Material reticleMaterial { get; }
    }

    public Pointer3DRaycaster raycaster;
    [FormerlySerializedAs("Target")]
    public Transform reticleForDefaultRay; // sphere
    public Transform reticleForCurvedRay; //pyramid
    public bool showOnHitOnly = true;

    public GameObject hitTarget; 
    public float hitDistance;
    public Material defaultReticleMaterial;
    public MeshRenderer[] reticleRenderer;
    public GameObject scriptViveEventsController;
    private ViveEventsController viveEventsController;
    private bool isPressingRight = false;
    private bool isPressingLeft = false;
    private Material m_matFromChanger;
#if UNITY_EDITOR
    protected virtual void Reset()
    {
        for (var tr = transform; raycaster == null && tr != null; tr = tr.parent)
        {
            raycaster = tr.GetComponentInChildren<Pointer3DRaycaster>(true);
        }

        reticleRenderer = GetComponentsInChildren<MeshRenderer>(true);
    }
#endif

    private void Update()
    {
        

    }
    protected virtual void LateUpdate()
    {
        var points = raycaster.BreakPoints;
        var pointCount = points.Count;
        var result = raycaster.FirstRaycastResult();

        if ((showOnHitOnly && !result.isValid) || pointCount <= 1)
        {
            reticleForDefaultRay.gameObject.SetActive(false);
            reticleForCurvedRay.gameObject.SetActive(false);
            return;
        }

        var isCurvedRay = raycaster.CurrentSegmentGenerator() != null;

        if (reticleForDefaultRay != null) { reticleForDefaultRay.gameObject.SetActive(!isCurvedRay); }
        if (reticleForCurvedRay != null) { reticleForCurvedRay.gameObject.SetActive(isCurvedRay); }

        var targetReticle = isCurvedRay ? reticleForCurvedRay : reticleForDefaultRay;

        if (ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Trigger))
            isPressingLeft = false;
        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger))
            isPressingLeft = true;
        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger))
            isPressingRight = false;
        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
            isPressingRight = true;

        if (result.isValid)
        {
            if (targetReticle != null)
            {
                targetReticle.position = result.worldPosition;
                targetReticle.rotation = Quaternion.LookRotation(result.worldNormal, raycaster.transform.forward);
            }

            hitTarget = result.gameObject;
            hitDistance = result.distance;


            
           if (viveEventsController != null )
           {
                viveEventsController = scriptViveEventsController.GetComponent<ViveEventsController>();
                viveEventsController.GetComponent<ViveEventsController>();
                if (hitTarget.layer == 8)
                {
                    if (isPressingLeft && ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
                    {
                        viveEventsController.leftRightHandTrigger(hitTarget);
                    }
                    else if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
                    {
                        viveEventsController.rightHandTrigger(hitTarget);
                    }
                }
                else
                {
                    if (!isPressingLeft && ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
                    {
                        viveEventsController.GetComponent<ViveEventsController>();
                        viveEventsController.ClearAllSelections();
                    }
                }
            }
            
        }
        else
        {
            if (targetReticle != null)
            {
                targetReticle.position = points[pointCount - 1];
                targetReticle.rotation = Quaternion.LookRotation(points[pointCount - 1] - points[pointCount - 2], raycaster.transform.forward);
            }
            if (viveEventsController != null && !isPressingLeft && ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
            {
                viveEventsController.GetComponent<ViveEventsController>();
                viveEventsController.ClearAllSelections();
            }
            hitTarget = null;
            hitDistance = 0f;
        }

        // Change reticle material according to IReticleMaterialChanger
        var matChanger = hitTarget == null ? null : hitTarget.GetComponentInParent<IMaterialChanger>();
        var newMat = matChanger == null ? null : matChanger.reticleMaterial;
        if (m_matFromChanger != newMat)
        {
            m_matFromChanger = newMat;

            if (newMat != null)
            {
                SetReticleMaterial(newMat);
            }
            else if (defaultReticleMaterial != null)
            {
                SetReticleMaterial(defaultReticleMaterial);
            }
        }
    }

    private void SetReticleMaterial(Material mat)
    {
        if (reticleRenderer == null || reticleRenderer.Length == 0) { return; }

        foreach (MeshRenderer mr in reticleRenderer)
        {
            mr.material = mat;
        }
    }

    protected virtual void OnDisable()
    {
        reticleForDefaultRay.gameObject.SetActive(false);
        reticleForCurvedRay.gameObject.SetActive(false);
    }
}
