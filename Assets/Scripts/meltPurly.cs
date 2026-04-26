using UnityEngine;
using UnityEngine.SceneManagement;

public class meltPurly : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("purly"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("MenuScene");
        }
    }
}
