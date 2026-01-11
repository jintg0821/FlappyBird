using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdJump : MonoBehaviour
{
    public static bool firstLaunch = true;

    public Animator animator;
    public RuntimeAnimatorController[] animatorControllers; 
    private Rigidbody2D rb;
    public float jumpPower;
    public GameObject GameOverPanel;
    public GameObject GameStartButton;
    public GameObject FontCredit;

    public bool isDie = false;

    public Sprite[] players;
    public Sprite[] playerDieSprites;
    public Sprite[] backgrounds;
    public SpriteRenderer backgroundImage;

    bool isMuted = false;
    public Sprite[] sounds;
    public Image soundImage;
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameOverPanel.SetActive(false);

        if (firstLaunch)
        {
            Time.timeScale = 0;
            GameStartButton.SetActive(true);
            firstLaunch = false;
        }
        else
        {
            Time.timeScale = 1;
            GameStartButton.SetActive(false);
            FontCredit.SetActive(false);
        }
    }

    void Update()
    {
        if (isDie && Time.timeScale == 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioClips[0]);
            rb.velocity = Vector2.up * jumpPower;
        }

        if (Score.score >= 2)
        {
            GetComponent<SpriteRenderer>().sprite = players[1];
            animator.runtimeAnimatorController = animatorControllers[1];
            backgroundImage.sprite = backgrounds[1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDie) return;

        if (!collision.gameObject.CompareTag("Obstacles0") &&
            !collision.gameObject.CompareTag("Obstacles1"))
            return;

        isDie = true;

        if (collision.gameObject.CompareTag("Obstacles0"))
            audioSource.PlayOneShot(audioClips[1]);

        if (collision.gameObject.CompareTag("Obstacles1"))
            audioSource.PlayOneShot(audioClips[2]);

        audioSource.PlayOneShot(audioClips[3]);

        if (Score.score > Score.bestScore)
            Score.bestScore = Score.score;

        StartCoroutine(LoadGameOverAfterSound());
    }

    IEnumerator LoadGameOverAfterSound()
    {
        yield return new WaitForSeconds(audioClips[3].length);
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            audioMixer.SetFloat("Master", -80f);
            soundImage.sprite = sounds[1];
        }
        else
        {
            audioMixer.SetFloat("Master", 0f);
            soundImage.sprite = sounds[0];
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
