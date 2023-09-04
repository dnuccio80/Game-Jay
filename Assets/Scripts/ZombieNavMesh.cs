using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ZombieNavMesh : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject panelUI;
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private Transform grenTick;
    [SerializeField] private Transform InterrogationSimbol;

    [TextArea]
    [SerializeField] private string textToUIEnglish;
    [TextArea]
    [SerializeField] private string textToUISpanish;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private bool canFollow = false;
    private bool firstTime = true;
    private Vector3 initialPosition;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        PotionsGameLogic.Instance.OnRestartGame += PotionsGameLogic_OnRestartGame;
    }

    private void PotionsGameLogic_OnRestartGame(object sender, System.EventArgs e)
    {
        firstTime = true;
        canFollow = false;
        transform.position = initialPosition;
        gameObject.SetActive(false);
        InterrogationSimbol.gameObject.SetActive(true);
        grenTick.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (canFollow)
        {
            navMeshAgent.destination = player.position;
            if(Vector3.Distance(transform.position, player.position) >= navMeshAgent.stoppingDistance)
            {
                animator.SetBool("IsWalking", true);
            } else
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(firstTime)
            {
                panelUI.SetActive(true);
                if(PlayerPrefs.GetInt("language") == 0)
                {
                    textUI.text = textToUIEnglish;
                } else if (PlayerPrefs.GetInt("language") == 1)
                {
                    textUI.text = textToUISpanish;
                }
                    
                InterrogationSimbol.gameObject.SetActive(false);
                grenTick.gameObject.SetActive(true);
            }
        }

        if(other.gameObject.tag == "BlackWitch")
        {
            canFollow = false;
            PotionsGameLogic.Instance.ZombieArrivedFine();
            animator.SetBool("IsWalking", false);
            Invoke("DesactiveZombie", 25);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(firstTime)
            {
                panelUI.SetActive(false);
                canFollow = true;
                firstTime = false;
            }
        }
    }

    private void DesactiveZombie()
    {
        gameObject.SetActive(false);
    }


}
