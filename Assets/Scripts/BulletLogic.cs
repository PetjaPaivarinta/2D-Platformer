using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletLogic : MonoBehaviour
{
    private float bulletSpeed = 40f;
    public GameObject MuzzleFlashPrefab;
    public GameObject bulletPrefab;
    public Text ammoText;
    public int ammoCount = 10;
    private float fireRate = 0.7f;
    public bool facingRight = true;
    public bool canShoot = true;
    public float recoilAngle = 10f;
    private float recoilSpeed = 5f;
    private float currentRecoil = 0f;

    void Start() {
        ammoText.text = ammoCount.ToString();
    }

    public void UpdateAmmoText()
{
    ammoText.text = ammoCount.ToString();
}

IEnumerator ShootDelay()
{
    yield return new WaitForSeconds(fireRate);
    canShoot = true;
}

public void Shoot()
{
    if (canShoot && ammoCount > 0)
    {
        FireBullet();
        ammoCount--;
        ammoText.text = ammoCount.ToString();
        canShoot = false;
        StartCoroutine(ShootDelay());
        currentRecoil += recoilAngle;
    }
}

void FireBullet()
{
    // Calculate the bullet position
    Vector2 bulletPos = (Vector2)transform.position * (facingRight ? 1 : -1);

    // Instantiate the bullet
    GameObject bullet = Instantiate(bulletPrefab, bulletPos, transform.rotation);

    // Get the Rigidbody2D component of the bullet
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    // Set the velocity of the bullet
    rb.velocity = (facingRight ? transform.right : -transform.right) * bulletSpeed;
}

void Update()
{
    if (Input.GetButtonDown("Fire1") && ammoCount > 0)
    {
        Shoot();
        showMuzzleFlash();

    }
    currentRecoil = Mathf.Lerp(currentRecoil, 0, Time.deltaTime * recoilSpeed);
}

IEnumerator showMuzzleFlash()
{
    MuzzleFlashPrefab.SetActive(true);
    yield return new WaitForSeconds(0.1f);
    MuzzleFlashPrefab.SetActive(false);

void FixedUpdate () {
		if (transform.position.y < -10) {
			Destroy(gameObject);
        }
        if (ammoCount > 1) {
            ammoText.text = "Find Ammo!";
        }
	}
}
}