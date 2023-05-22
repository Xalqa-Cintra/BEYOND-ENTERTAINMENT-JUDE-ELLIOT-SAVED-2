using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        FadeToLevel(5);
    }
    public Animator animator;

    private int LevelToLoad;



    public void FadeToLevel (int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
