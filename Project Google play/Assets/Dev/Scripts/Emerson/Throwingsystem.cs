using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Throwingsystem : MonoBehaviour
{
    private BallPooling ballPool;
    Vector2 m_startPos, m_endPos;
    Vector2 m_Debug;
    Vector3 m_direction;
    float m_touchTimeStart, m_touchTimeFinish, m_timeInterval;

    public float forwardForce;
    public float sideForce;
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private TMP_Text m_DebugText;

#if UNITY_EDITOR
    private void Start()
    {
        ballPool = FindObjectOfType<BallPooling>();
        StartCoroutine(ThrowPreocedureAsync());
    }
#elif UNITY_ANDROID
private void Start()
    {
        ballPool = FindObjectOfType<BallPooling>();
        StartCoroutine(ThrowPreocedureAsync());
    }
#endif
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        m_DebugText.text = m_Debug.x + "," + m_Debug.y;
    }

    private IEnumerator ThrowPreocedureAsync()
    {
        ballRigidbody.transform.eulerAngles = Vector3.right * -45f;
#if UNITY_EDITOR
        while (!Input.GetMouseButtonDown(0))
#else
        while (Input.touchCount > 0 && Input.touches[0].phase != TouchPhase.Began)
#endif
        {
            yield return null;
        }

        Vector2 originalTouchPosition = Input.mousePosition;
        float startTime = Time.time;

        m_Debug = originalTouchPosition;
        while (!Input.GetMouseButtonUp(0))
        {
            yield return null;
        }

        float dragDuration = Time.time - startTime;
        Vector2 dragDelta = (Vector2)Input.mousePosition - originalTouchPosition;
        dragDelta.x /= Screen.width;
        dragDelta.y /= Screen.height;

        ballRigidbody.isKinematic = false;
        yield return null;
        ballRigidbody.AddRelativeForce(dragDelta.x * sideForce, 0f, Mathf.Pow(dragDelta.y + 1f, 1.5f) * forwardForce);
        ballPool.Invoke("EnableNewBall", 0.75f);
    }
}
