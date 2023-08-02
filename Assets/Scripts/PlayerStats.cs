using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StarterAssets;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    private Animator animator;
    private CharacterController characterController;
    private ThirdPersonController thirdPersonController;
    private ThirdPersonShooterController thirdPersonShooterController;
    private TracePlayer tracePlayer;

    public event EventHandler OnPlayerDeath;

    [Range(0,100)] private int life = 100;
    private int maxLife = 100;
    [Range(0, 100)] private int gunAmmo = 100;
    private int maxGunAmmo = 100;
    [SerializeField] private Slider lifeSlider;
    [SerializeField] private Slider gunSlider;

    private int ammoTimer = 0;
    private int ammoMaxTimer = 3;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
        tracePlayer = GetComponent<TracePlayer>();
    }

    private void Start()
    {
        lifeSlider.value = life/100f;
    }

    private void Update()
    {
        if (gunAmmo < maxGunAmmo)
        {
            ammoTimer++;

            if (ammoTimer >= ammoMaxTimer)
            {
                IncrementAmmo();
                ammoTimer = 0;
            }
        }
        else if (gunAmmo >= maxGunAmmo) gunAmmo = maxGunAmmo;

    }


    public void ReduceLife(int lifeReduce)
    {
        life -= lifeReduce;
        lifeSlider.value = life / 100f;
        if (life <= 0)
        {
            animator.SetTrigger("Die");
            characterController.enabled = false;
            thirdPersonController.enabled = false;
            thirdPersonShooterController.enabled = false;
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public void IncrementLife(int lifeIncrement)
    {
        life += lifeIncrement;
        if (life > maxLife) life = maxLife;
        lifeSlider.value = life / 100f;
    }

    public bool GetIfLifeIsFull()
    {
        return (life == 100);
    }

    public void ReduceGunAmmo()
    {
        gunAmmo-= 10;
        gunSlider.value = gunAmmo / 100f;
    }

    private void IncrementAmmo()
    {
        gunAmmo++;
        gunSlider.value = gunAmmo / 100f;
    }
    
    public bool GetIfAmmoIsEmpty()
    {
        return (gunAmmo <= 0);
    }

    public void RestartPlayerStats()
    {
        life = 100;
        gunAmmo = maxGunAmmo;
        lifeSlider.value = life / 100f;
        gunSlider.value = gunAmmo / 100f;
        animator.SetTrigger("Revive");
        characterController.enabled = true;
        thirdPersonController.enabled = true;
        thirdPersonShooterController.enabled = true;
        tracePlayer.MovePlayerToScene();
    }

    


}
