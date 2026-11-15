using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public static class playerType
{
    public static bool isLight;
    public static bool isGracePeriod;
    public static bool ded;
    public static Behaviour[] movementProviders;
}

public class typeOfCat : MonoBehaviour
{
    public Behaviour[] movementProviders;
    public InputActionReference changeButton;
    public int gracePeriodDuration = 2;
    public Slider gracePeriodSlider;
    private float timeLeft = 0;
    public Slider shadowSlider;
    public float shadowChangeDuration = 20;
    private float shadowTimeLeft = 0;
    private bool lastChanged = false;
    public GameObject whitePaw1;
    public GameObject whitePaw2;
    public GameObject blackPaw1;
    public GameObject blackPaw2;
    private Coroutine shadowRoutine;
    public GameObject dedScreen;
    void Start()
    {
        playerType.isLight = true;
        changeButton.action.Enable();
        changeButton.action.performed += onButtonPressed;
        playerType.movementProviders = movementProviders;
    }
    private void onButtonPressed(InputAction.CallbackContext context){
        if(playerType.isGracePeriod == false){
            playerType.isLight = !playerType.isLight;
            lastChanged = true;
            if(playerType.isLight == false)
            {
                shadowRoutine = StartCoroutine(shadowTimer());
            }
            else
            {
                StopCoroutine(shadowRoutine);
                shadowRoutine = null;
                shadowTimeLeft = 0;
            }
            playerType.isGracePeriod = true;
            StartCoroutine(gracePeriodTimer());
        }
    }
    private IEnumerator gracePeriodTimer(){
        timeLeft = gracePeriodDuration;
        yield return new WaitForSeconds(gracePeriodDuration);
        gracePeriodFinished();
    }
    private IEnumerator shadowTimer()
    {
        shadowTimeLeft = shadowChangeDuration;
        yield return new WaitForSeconds(shadowChangeDuration);
        playerType.isLight = !playerType.isLight;
        playerType.isGracePeriod = true;
        lastChanged = true;
        StartCoroutine(gracePeriodTimer());
    }
    private void gracePeriodFinished(){
        playerType.isGracePeriod = false;
    }

    void Update()
    {
        if(timeLeft>=0){
            timeLeft -= Time.deltaTime;
            gracePeriodSlider.value = timeLeft/gracePeriodDuration;
        }
        if (shadowTimeLeft >= 0)
        {
            shadowTimeLeft -= Time.deltaTime;
            shadowSlider.value = shadowTimeLeft/shadowChangeDuration;
        }
        if (lastChanged)
        {
            if (playerType.isLight)
            {
                whitePaw1.SetActive(true);
                blackPaw1.SetActive(false);
                whitePaw2.SetActive(true);
                blackPaw2.SetActive(false);
            }
            else
            {
                whitePaw1.SetActive(false);
                blackPaw1.SetActive(true);
                whitePaw2.SetActive(false);
                blackPaw2.SetActive(true);
            }
            lastChanged = false;
        }
        if(playerType.ded == true)
        {
            Debug.Log("ded");
            foreach(var provider in playerType.movementProviders)
            {
                provider.enabled = false;
            }
            dedScreen.SetActive(true);
            playerType.ded = false;
        }
    }
}