using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int _health;

    [SerializeField] protected float _shotSpeed;
    [SerializeField] protected float _range;
    [SerializeField] protected float _aggroRange;
    [SerializeField] protected float _inaccuarcy;
    [SerializeField] protected float _aggroRange;
    protected float _shotCooldown;
    protected bool LOS;

    public Transform _player;

    private Transform cam;
    
    [SerializeField] protected bool showGizmo;

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    
    protected virtual void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        LOS = false;
        Ray losRay = new Ray(transform.position, _player.position - transform.position);
        if (Physics.Raycast(losRay, out RaycastHit losHit, _aggroRange))
        {
            if (losHit.transform.CompareTag("Player"))
                LOS = true;
        }

        Debug.DrawRay(losRay.origin, losRay.direction * _aggroRange);

        if (Vector3.Distance(_player.position, transform.position) < _range)
        {
            if (_shotCooldown < _shotSpeed)
            {
                _shotCooldown += Time.deltaTime;
            }
            else
            {
                _shotCooldown = 0;
                float xInac = Random.Range(0, _inaccuarcy);
                float yInac = Random.Range(0, _inaccuarcy);
                float zInac = Random.Range(0, _inaccuarcy);
                float rayL = _range;
                Ray ray = new Ray(transform.position, transform.forward + new Vector3(xInac, yInac, zInac));
                if (Physics.Raycast(ray, out RaycastHit hit, _range))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        Debug.Log("Player Hit");
                        rayL = Vector3.Distance(hit.point, transform.position);
                    }
                    else
                    {
                        Debug.Log("Player Missed");
                    }

                    Debug.DrawRay(transform.position, (transform.forward + new Vector3(xInac, yInac, zInac)) * rayL, Color.green, _range);
                }
            }
        }
    }

    public void Hit()
    {
        _health--;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDrawGizmos()
    {
        if (showGizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _aggroRange);
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }

    protected void YBillboard()
    {
        transform.LookAt(cam);

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    protected void Billboard()
    {
        transform.LookAt(cam);
    }
}