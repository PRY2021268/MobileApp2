using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;


public class Server : MonoBehaviour
{
	[SerializeField] GameObject welcomePanel;
	[SerializeField] GameObject registerPanel;
	[SerializeField] GameObject loginPanel;
	[SerializeField] Text user;
	
	[SerializeField] InputField username;
	[SerializeField] InputField password;
	[SerializeField] InputField regEmail;
	[SerializeField] InputField regUsername;
	[SerializeField] InputField regPassword;

	[SerializeField] Text errorMessages;
	[SerializeField] Text errorMessagesRegister;
	[SerializeField] GameObject progressCircle;


	[SerializeField] Button loginButton;
	[SerializeField] Button goToRegisterButton;
	[SerializeField] Button registerButton;



	[SerializeField] string url;

	WWWForm form;

	public void OnLoginButtonClicked ()
	{
		loginButton.interactable = false;
		progressCircle.SetActive (true);
		StartCoroutine (Login ());
	}
	public void OnRegisterButtonClicked()
	{
		registerButton.interactable = false;
		progressCircle.SetActive(true);
		StartCoroutine(SignUp());
	}

	public void goToRegisterButtonClicked()
	{
		goToRegisterButton.interactable = false;
		registerPanel.SetActive(true);
		loginPanel.SetActive(false);
	}

	IEnumerator SignUp ()
    {
		form = new WWWForm();

		form.AddField("email", regEmail.text);
		form.AddField("username", regUsername.text);
		form.AddField("password", regPassword.text);

		UnityWebRequest w = UnityWebRequest.Post(url+"/register", form);
		yield return w.SendWebRequest();

		if (w.error != null)
		{
			errorMessagesRegister.text = "404 not found!";
			Debug.Log("<color=red>" + w.result + "</color>");//error
		}
		else
		{
			if (w.isDone)
			{
				if (w.result != UnityWebRequest.Result.Success)
				{
					errorMessagesRegister.text = "invalid username or password!";
					Debug.Log("<color=red>" + "There was an error" + "</color>");//error
				}
				else
				{
					welcomePanel.SetActive(true);
					user.text = username.text;
					Debug.Log("<color=green>" + w.result + "</color>");//user exist
				}
			}
		}

		registerButton.interactable = true;
		progressCircle.SetActive(false);

		w.Dispose();
	}

	IEnumerator Login ()
	{
		form = new WWWForm ();

		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		UnityWebRequest w = UnityWebRequest.Post(url + "/register", form);
		yield return w.SendWebRequest();

		if (w.error != null) {
			errorMessages.text = "404 not found!";
			Debug.Log("<color=red>"+w.result+"</color>");//error
		} else {
			if (w.isDone) {
				if (w.result != UnityWebRequest.Result.Success)
				{
					errorMessages.text = "invalid username or password!";
					Debug.Log("<color=red>" + "There was an error" + "</color>");//error
				}
				else
				{
					welcomePanel.SetActive(true);
					user.text = username.text;
					Debug.Log("<color=green>" + w.result + "</color>");//user exist
				}
			}
		}

		loginButton.interactable = true;
		progressCircle.SetActive (false);

		w.Dispose ();
	}
}
