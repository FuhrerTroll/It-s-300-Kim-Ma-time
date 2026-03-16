using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float moveDistance = 1f;   // khoảng cách gai trồi lên
    public float upTime = 1f;         // thời gian giữ khi trồi lên
    public float downTime = 2f;       // thời gian giữ khi thụt xuống
    public float moveSpeed = 5f;      // tốc độ di chuyển

    private Vector3 startPos;
    private Vector3 upPos;

    void Start()
    {
        startPos = transform.position;
        upPos = startPos + Vector3.up * moveDistance;

        StartCoroutine(SpikeCycle());
    }

    IEnumerator SpikeCycle()
    {
        while (true)
        {
            // Di chuyển lên
            yield return StartCoroutine(MoveTo(upPos));

            // Giữ 1s
            yield return new WaitForSeconds(upTime);

            // Di chuyển xuống
            yield return StartCoroutine(MoveTo(startPos));

            // Giữ 2s
            yield return new WaitForSeconds(downTime);
        }
    }

    IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }
}