using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveDistance = 2.0f;
    private float rotateAngle = 45f;
    public GameObject player;
    private Rigidbody2D rb;
    private bool isRoaming = true;
    private bool shouldReturnToRoaming = false;
    public GameObject[] aiGuns;
    public GameObject bulletPrefab;
    public Transform aiGunHolder;
    public Transform aiNozzle;


    private bool canFire = true;
    private Coroutine moveAndRotateCoroutine;
    private Coroutine shootingAtPlayerCoroutine;
    void Start()
    {
        GameObject aiGun = Instantiate(aiGuns[Random.Range(0, aiGuns.Length)], aiGunHolder.position, aiGunHolder.rotation);
        aiGun.transform.parent = this.transform;
        rb = GetComponent<Rigidbody2D>();
        moveAndRotateCoroutine = StartCoroutine(MoveAndRotate());

    }

    private void Update()
    {
        if (player != null)
        {
            StopAllCoroutines();
            shouldReturnToRoaming = true;
            //StartCoroutine(FacePlayer());
        }
    }
    public void FaceTarget(GameObject theTarget)
    {
        //isRoaming = false;


        shootingAtPlayerCoroutine = StartCoroutine(FireRoutine(theTarget));
        //yield return new WaitForSeconds(0.5f);

        /*        if (shouldReturnToRoaming)
                {

                    //StartCoroutine(ReturnToRoaming());
                    yield break;
                }*/
    }
    public void ReturnToRoam()
    {
        if (shootingAtPlayerCoroutine != null)
        {
            StopCoroutine(shootingAtPlayerCoroutine);
        }

        moveAndRotateCoroutine = StartCoroutine(MoveAndRotate());

    }
    private void FirePlayer()
    {
        Instantiate(bulletPrefab, aiNozzle.position, aiNozzle.rotation);
    }

    private IEnumerator FireRoutine(GameObject theTarget)
    {
        while (true)
        {
            if (canFire)
            {
                //StopCoroutines((MoveAndRotate()));
                StopCoroutine(moveAndRotateCoroutine);
                Vector2 directionToPlayer = theTarget.transform.position - transform.position;
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
                StartCoroutine(RotateToRotation(targetRotation));
                FirePlayer();
                canFire = false;
                yield return new WaitForSeconds(1f);
                canFire = true;
            }
            yield return null;
        }
    }

    public void ActivateReturnToRoaming()
    {
        if (!isRoaming)
        {
            shouldReturnToRoaming = true;
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            StopAllCoroutines();
            //StartCoroutine(ReturnToRoaming());
        }
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void OnEnable()
    {
        if (!isRoaming)
        {
            isRoaming = true;
            StartCoroutine(MoveAndRotate());
        }
    }

    IEnumerator MoveAndRotate()
    {
        while (true)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;


            float randomRotation = Random.Range(-rotateAngle, rotateAngle);

            Vector2 newPosition = rb.position + randomDirection * moveDistance;
            Quaternion newRotation = Quaternion.Euler(0f, 0f, rb.rotation + randomRotation);

            StartCoroutine(MoveToPosition(newPosition));
            StartCoroutine(RotateToRotation(newRotation));

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        float elapsedTime = 0f;
        float moveTime = 0.5f;

        Vector2 startPosition = rb.position;

        while (elapsedTime < moveTime)
        {
            rb.MovePosition(Vector2.Lerp(startPosition, targetPosition, elapsedTime / moveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPosition);
    }

    IEnumerator RotateToRotation(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        float rotateTime = 0.5f;

        Quaternion startRotation = transform.rotation;

        while (elapsedTime < rotateTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotateTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}