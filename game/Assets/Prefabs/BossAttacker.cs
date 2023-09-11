using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacker : MonoBehaviour
{
    [SerializeField] private List<Transform> _shootPoints;

    [SerializeField] private GameObject _bulletPrefab;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        transform.position = new Vector3(1,1,transform.position.z);
        StartCoroutine(Move(2, 2));
        StartCoroutine(Shoot(3, 0.3f));

    }

    private IEnumerator Shoot(float salvoDelay, float shootDilay)
    {
        float startSalvo = 0;
        while (true)
        {
            startSalvo = Time.time;
            while (true)
            {
                if (startSalvo + salvoDelay >= Time.time)
                {
                    Shoot();
                    yield return new WaitForSeconds(shootDilay);
                }
                else
                {
                    break;
                }
            }
            startSalvo = 0;
            yield return new WaitForSeconds(salvoDelay);
        }
    }
    public void Shoot()
    {
        var shootPoint = GetRandomShootPoint();

        var bulletPawn = Instantiate(_bulletPrefab, shootPoint.position, shootPoint.rotation);

        Bullet bullet = bulletPawn.GetComponent<EnemyBullet>();

        Destroy(bulletPawn, bullet.LiveTime);
    }
    private Transform GetRandomShootPoint()
    {
        return _shootPoints[Random.Range(0, _shootPoints.Count)];
    }
    private IEnumerator Move(float delayBetweenMoving, float duration)
    { 
        while (true)
        {
            //2
            StartCoroutine(MoveByDirection(new Vector3(0, -1, 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //3
            StartCoroutine(MoveByDirection(new Vector3(Mathf.Cos(Mathf.PI * 5 / 6), Mathf.Sin(Mathf.PI * 5 / 6), 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //4
            StartCoroutine(MoveByDirection(new Vector3(Mathf.Cos(Mathf.PI * 7 / 6), Mathf.Sin(Mathf.PI * 7 / 6), 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //5
            StartCoroutine(MoveByDirection(new Vector3(Mathf.Cos(Mathf.PI * 3 / 6), Mathf.Sin(Mathf.PI * 3 / 6), 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //6
            StartCoroutine(MoveByDirection(new Vector3(Mathf.Cos(Mathf.PI * 11 / 6), Mathf.Sin(Mathf.PI * 11 / 6), 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //7
            StartCoroutine(MoveByDirection(new Vector3(0, -1, 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //8
            StartCoroutine(MoveByDirection(new Vector3(Mathf.Cos(Mathf.PI / 6), Mathf.Sin(Mathf.PI / 6), 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
            //9
            StartCoroutine(MoveByDirection(new Vector3(0, 1, 0), duration));
            yield return new WaitForSeconds(delayBetweenMoving);
        }

    }
    private IEnumerator MoveByDirection(Vector3 Direction, float duration)
    {
        float startMove = 0;
        while (true)
        {
            if (startMove <= duration)
            {
                characterController.Move(Direction * Time.deltaTime);
                startMove += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            else
                break;
        }
    }
}

