using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public bool isRayCast;
    public Transform firePoint;
    public GameObject bulletPrefab;
    
	public int damage = 40;
	public GameObject impactEffect;
	public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
			if(isRayCast)
			{
			StartCoroutine(Shoot());
			}
			else 
			{
				FirePrefab();
			}
        }
    }

    IEnumerator Shoot ()
    {
        // Shooting Logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

		if (hitInfo)
		{
			Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			var clone = Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, hitInfo.point);
			yield return 0;
			Destroy(clone);
		} else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
		}

		lineRenderer.enabled = true;

		yield return 0;

		lineRenderer.enabled = false;
    }

	void FirePrefab()
	{
		
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
