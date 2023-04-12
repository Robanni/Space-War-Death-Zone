using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{

    [DllImport("__Internal")]

    private static extern void ShowRespawnAdv();

    [DllImport("__Internal")]
    private static extern void ShowDeathAdv();

    public void RespawnButton()
    {
        ShowRespawnAdv();
    }

    public void DeathAdv()
    {
        ShowDeathAdv();
    }

}
