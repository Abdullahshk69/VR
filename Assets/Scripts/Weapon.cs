using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected float recoilForce;
    [SerializeField] protected float damage;

    private Rigidbody rb;
    private XRGrabInteractable interactableWeapon;

    [Obsolete]
    protected virtual void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        SetupInteractableEvents();
    }

    [Obsolete]
    private void SetupInteractableEvents()
    {
        interactableWeapon.onSelectEntered.AddListener(PickUpWeapon);
        interactableWeapon.onSelectExit.AddListener(DropWeapon);
        interactableWeapon.onActivate.AddListener(StartShooting);
        interactableWeapon.onDeactivate.AddListener(StopShooting);
    }

    private void PickUpWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHider>().Hide();
    }

    private void DropWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHider>().Show();
    }

    protected virtual void StartShooting(XRBaseInteractor interactor)
    {
        //throw new NotImplementedException();
    }

    protected virtual void StopShooting(XRBaseInteractor interactor)
    {
        //throw new NotImplementedException();
    }

   protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rb.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage()
    {
        return damage;
    }
}
