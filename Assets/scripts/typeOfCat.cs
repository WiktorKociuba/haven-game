using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public static class playerType
{
    public static bool isLight;
    public static bool isGracePeriod;
}

public class typeOfCat : MonoBehaviour
{
    public InputActionReference changeButton;
    public int gracePeriodDuration = 2;
    public Slider gracePeriodSlider;
    private float timeLeft = 0;
    void Start()
    {
        playerType.isLight = true;
        changeButton.action.Enable();
        changeButton.action.performed += onButtonPressed;
    }
    private void onButtonPressed(InputAction.CallbackContext context){
        if(playerType.isGracePeriod == false){
            playerType.isLight = !playerType.isLight;
            playerType.isGracePeriod = true;
            StartCoroutine(gracePeriodTimer());
        }
    }
    private IEnumerator gracePeriodTimer(){
        timeLeft = gracePeriodDuration;
        yield return new WaitForSeconds(gracePeriodDuration);
        gracePeriodFinished();
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
    }
}