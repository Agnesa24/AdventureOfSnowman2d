using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifetime = 10f;

    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("purly"))
        {
            GameData.SaveScore();
            Destroy(collision.gameObject);
            SceneManager.LoadScene("MenuScene");
        }
    }
}