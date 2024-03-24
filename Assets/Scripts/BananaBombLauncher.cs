using UnityEngine;

public class BananaBombLauncher : MonoBehaviour
{
    public BananaBomb BananaBombPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        BananaBomb Grenade = Instantiate(BananaBombPrefab, transform.position, transform.rotation);
        Grenade.transform.LookAt(GetTargetPoint());
    }

    Vector3 GetTargetPoint()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 1.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
}