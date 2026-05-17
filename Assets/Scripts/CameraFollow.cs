using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float minX;
    public float maxX;
    public float fixedY = 0f;

    void LateUpdate()
    {
        if (target == null)
        {
            SceneManager.LoadScene("MenuScene"); 
            return;
        }

        float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, fixedY, transform.position.z);
    }
}