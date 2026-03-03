using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootSpeed;

    private float timer;
    [SerializeField] private float timeBetweenBullets = 2f;
    void Update ()
    {
        timer += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && timer >= timeBetweenBullets)
        {
            Shoot();
            timer = 0f;
        }
    }


    void Shoot ()
    {
      //check ammo amount
    if(gameObject.GetComponent<PlayerHealth>().currentAmmo <= 0)
    {
            Debug.Log("no ammo");
            return;
    }

    Debug.Log("shoot");

    gameObject.GetComponent<PlayerHealth>().currentAmmo--;
    //generate projectile
    GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation,null);

    bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootSpeed, ForceMode.Impulse);
    gameObject.GetComponent<PlayerHealth>().UpdateAmmo();

    }
}
