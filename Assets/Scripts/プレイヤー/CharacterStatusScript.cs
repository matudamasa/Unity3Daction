using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStatusScript : MonoBehaviour
{
    //Animator anim;
    public UnityEvent onDieCallback = new UnityEvent();

    public int life = 300;

    public Slider hpBar;

    void Start()
    {
        //anim = GetComponent<Animator>();

        if (hpBar != null)
        {
            hpBar.value = life;
        }
    }
    public void Heal(int heal)
    {
        if (life <= 0 || life>=250  ) return;

        life += heal;
        if (hpBar != null)
        {
            hpBar.value = life;
        }
    }

    public void Damage(int damage)
    {
        if (life <= 0) return;

        life -= damage;
        if (hpBar != null)
        {
            hpBar.value = life;
        }
        if (life <= 0)
        {
            OnDie();
        }
    }

    void OnDie()
    {
        // Scene‚ðÄ“Ç‚Ýž‚Ý
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //anim.SetBool("Die", true);
        //onDieCallback.Invoke();
    }
}