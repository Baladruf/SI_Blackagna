using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruche : MonoBehaviour {

    [SerializeField] int life;
    public bool isDestroy { get; private set; }
    public Transform spawnPlayer;
    [System.NonSerialized]
    public PlayerController player;
    [SerializeField] int damage = 5;
    private MeshRenderer SM_oeuf;
    public Color hitTintColor;
    private Color OriginalTintColor;
    public float HitTintTime = 1f;

    private Coroutine HitTintChange;

    private void Awake()
    {
        isDestroy = false;
        SM_oeuf = transform.GetChild(0).GetComponent<MeshRenderer>();
        OriginalTintColor = SM_oeuf.material.color;
    }

    public void TakeDamage(int damage)
    {


        var manager = GameManager.Instance;
        if (ReferenceEquals(manager.cadavre.cadavreWithPlayer, player))
            return;

        if (HitTintChange == null)
        {
            HitTintChange = StartCoroutine(HitTintColor());
        }
        life -= damage;
        if(life <= 0)
        {
            isDestroy = true;
            GameManager.Instance.RucheCount();
            player.InitInvincible();
            for(int i = 0; i < GameManager.Instance.players.Length; i++)
            {
                GameManager.Instance.players[i].AddRankBonus();
            }
            //dead ruche
            GameManager.Instance.AddIdDestroyRuche(player.id);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Shot")
        {
            TakeDamage(damage);
        }
    }

    private IEnumerator HitTintColor()
    {
        SM_oeuf.material.color = hitTintColor;
        yield return new WaitForSeconds(HitTintTime);
        SM_oeuf.material.color = OriginalTintColor;
        HitTintChange = null;
    }
}
