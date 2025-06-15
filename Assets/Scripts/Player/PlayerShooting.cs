using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public float damage = 10f;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public int maxAmmo = 10;           // Maximum rounds per clip
    public float fireRate = 15f;
    private float timer;
    public int currentAmmo;
    public AudioSource gunAudioSource;
    public AudioClip gunshotClip;
    public Transform fpsCam;
    public ParticleSystem muzzleFlash;  // Change this to GameObject
    public GameObject impactEffect;
    public Slider ammoBar;
    //private WeaponRecoil weaponRecoil;
    public Animator animator;
    public float reloadTime = 2f;      // Time it takes to reload
    private bool isReloading = false;
    private float nextTimeToFire = 0f;
    public TextMeshProUGUI reloadText;

    void Start()
    {

        gunAudioSource = GetComponent<AudioSource>();
        //weaponRecoil = GetComponent<WeaponRecoil>();
        currentAmmo = maxAmmo;

        if (ammoBar == null)
        {
            ammoBar = FindObjectOfType<Slider>();
        }

        // Set slider max value to maxAmmo
        ammoBar.maxValue = maxAmmo;
        // Initialize slider value
        ammoBar.value = currentAmmo;

        // Ensure the reload text is hidden at the start
        if (reloadText != null)
        {
            reloadText.enabled = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isReloading)
        {
            return;
        }

        if (reloadText != null)
        {
            reloadText.enabled = (currentAmmo <= 0);
        }

        if (currentAmmo <= maxAmmo*.8 && Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        ammoBar.value = currentAmmo;
    }


    void Shoot()
    {
        if (currentAmmo > 0)
        {
            timer = 0f;
            currentAmmo--;
            muzzleFlash.Play();
            Debug.Log("Shooting...");

            gunAudioSource.PlayOneShot(gunshotClip);

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log("Shooting " + hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 0.2f);
                    target.TakeDamage(damage);
                }

                DestroyGrave destroy = hit.transform.GetComponent<DestroyGrave>();
                if (destroy != null)
                {
                    destroy.TakeDamage(damage);
                }
                //weaponRecoil.ApplyRecoil();
            }
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;
        isReloading = false;

        // Hide the reload text after reloading
        if (reloadText != null)
        {
            reloadText.enabled = false;
        }
    }
}