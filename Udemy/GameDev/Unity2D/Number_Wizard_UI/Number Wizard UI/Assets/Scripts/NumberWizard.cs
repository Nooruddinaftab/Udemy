using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NumberWizard : MonoBehaviour {

	[SerializeField] TextMeshProUGUI guess_label;
	[SerializeField] Text min_label;
	[SerializeField] Text max_label;

	[SerializeField] int min_n ;
	[SerializeField] int max_n ;

	int guess_n ;
	// Use this for initialization
	void Start () {

		min_label.text = min_n.ToString();
		max_label.text = max_n.ToString();

		TakeGuess();

	}

	public void OnBtnClickHigher()
    {
		min_n = guess_n;
		TakeGuess();
	}

	public void OnBtnClickLower()
    {
		max_n = guess_n;

		TakeGuess();
	}


	void UpdateGuessLabel()
    {
		guess_label.text = guess_n.ToString();
	}

	void TakeGuess()
    {
		//guess_m = (min_n + max_n) / 2;
		guess_n = Random.Range(min_n, max_n + 1);
		UpdateGuessLabel();
	}
}
