using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public AudioSource gunAudioSource;
    public AudioClip gunshotClip;
    public float damage = 10f;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public Transform fpsCam;
    public ParticleSystem muzzleFlash;  // Change this to GameObject
    public GameObject impactEffect;
    public Slider ammoBar;
    public int maxAmmo = 10;           // Maximum rounds per clip
    public float reloadTime = 2f;      // Time it takes to reload
    public float fireRate = 15f;
    private float timer;
    public int currentAmmo;
    private bool isReloading = false;
    //private AudioSource gunAudio;
    //private AudioSource reloadAudio;
    //private Light gunLight;
    private float nextTimeToFire = 0f;
    private WeaponRecoil weaponRecoil;

    void Start()
    {
        gunAudioSource = GetComponent<AudioSource>();
        weaponRecoil = GetComponent<WeaponRecoil>();
        currentAmmo = maxAmmo;

        if (ammoBar == null)
        {
            ammoBar = FindObjectOfType<Slider>();
        }

        // Set slider max value to maxAmmo
        ammoBar.maxValue = maxAmmo;
        // Initialize slider value
        ammoBar.value = currentAmmo;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
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
        timer = 0f;
        currentAmmo--;
        //gunAudio.Play();
        muzzleFlash.Play();
        Debug.Log("Shooting...");

        gunAudioSource.PlayOneShot(gunshotClip);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Shooting " + hit.transform.name);

            DestroyGrave destroy = hit.transform.GetComponent<DestroyGrave>();
            if (destroy != null)
            {
                destroy.TakeDamage(damage);
            }

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Instantiate Impact Effect
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.2f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        //reloadAudio.Play();
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

}