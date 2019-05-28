using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class backgroundData : MonoBehaviour {
    public new static string name = "";
	void Awake() {
        //If you are reading this Powershell is a pain.....
        //This gets me their Name from Windows Active Directory (Or something like that)
        //More Info here: https://serverfault.com/questions/582696/retrieve-current-domain-users-full-name
        System.Diagnostics.Process envname = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "$user = whoami \nGet-WMIObject Win32_UserAccount | where caption -eq $user | select FullName | ft -hide",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };
        envname.Start();
        backgroundData.name = envname.StandardOutput.ReadToEnd().Split(" ".ToCharArray())[0];// System.Environment.UserName;
		UnityEngine.Debug.Log ("Hi " + name);
	}
    public void CallMePls(string selection)
    {
        UnityEngine.Debug.Log("TAYAYAY");
        if(selection == "Start")
        {
            SceneManager.LoadScene(1);
        } else
        {
            Application.Quit();
        }
    }
}
