using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public InputField email, username, password;
    public GameObject successPanel, failPanel, registerPanel, menuPanel, perfilPanel, 
                      logoutPanel, loginPanel, statisticsPanel;

    public void GoToPerfil(){
        menuPanel.SetActive(false);
        perfilPanel.SetActive(true);
    }

    public void OpenLogout() {
        logoutPanel.SetActive(true);
    }

    public void CancelLogout() {
        logoutPanel.SetActive(false);
    }

    public void Logout() {
        perfilPanel.SetActive(false);
        logoutPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    bool IsValidEmail(string email) {
        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        } catch { return false; }
    }

    public void Register() {
        if (email.text.Length >= 6 && username.text.Length >= 3 && password.text.Length >= 6
            && IsValidEmail(email.text) && !String.IsNullOrWhiteSpace(username.text) && !String.IsNullOrWhiteSpace(password.text)) {
            successPanel.SetActive(true);
        } else {
            failPanel.SetActive(true);
        }
    }

    public void GoToMenu() {
        registerPanel.SetActive(false);
        successPanel.SetActive(false);
        email.text = ""; username.text = ""; password.text = "";
        menuPanel.SetActive(true);
    }

    public void ReturnMenuFromPerfil() {
        perfilPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void GoToStatistics() {
        perfilPanel.SetActive(false);
        statisticsPanel.SetActive(true);
    }

    public void ReturnPerfilFromStatistics() {
        statisticsPanel.SetActive(false);
        perfilPanel.SetActive(true);
    }

    public void RetryRegister() {
        failPanel.SetActive(false);
    }
}
