using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;


public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] GameObject crossHair;
    [SerializeField] private LayerMask aimColliderMask = new LayerMask();
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform aimTarget;
    [SerializeField] private Rig aimingRig;
    [SerializeField] private Transform gun;
    [SerializeField] private AudioClip emptyBullet;

    private StarterAssetsInputs starterAssets;
    private ThirdPersonController thirdPersonController;
    private Animator animator;
    private AudioSource audioSource;

    private bool _aimShooting = false;

    private void Awake()
    {
        starterAssets = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
            
        }

        if (starterAssets.aim && !CubicGameLogic.Instance.GetIfHasAnObject())
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            crossHair.SetActive(true);
            thirdPersonController.SetRotateOnMove(false);
            _aimShooting = true;
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            aimTarget.position = raycastHit.point;
            aimingRig.weight = 1f;
            gun.gameObject.SetActive(true);


            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;



            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        } else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            crossHair.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            _aimShooting = false;
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            aimingRig.weight = 0f;
            gun.gameObject.SetActive(false);

        }

        if (starterAssets.shoot)
        {
            if (_aimShooting)
            {
                if (!PlayerStats.Instance.GetIfAmmoIsEmpty())
                {
                    Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                    Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                    audioSource.Play();
                    animator.SetTrigger("fireGun");
                    starterAssets.shoot = false;
                    PlayerStats.Instance.ReduceGunAmmo();
                } 
                
            }
        }


    }

}
