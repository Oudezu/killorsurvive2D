using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChestScript : MonoBehaviour {
    public bool isOpen;
    [Range(0f,15f)]
    public float progress = 0f;

    public Utils.keyType _key;
    public GameObject _press_action;        // Pressing the Actio Button
    public GameObject _loadingbar;          // The bar which raises the fill amount
    public GameObject _loading_process;     // Object for the text of the aktual process
    public GameObject _radialprocessbar;    // The whole Object of the Process Image

    private float _anim_time;

    private Image _loadingbar_img;
    private Text _loading_process_text;
    private Animation _anim_press_action;

    // Use this for initialization
    void Start () {
        isOpen = false;
        
        _anim_press_action = _press_action.GetComponent<Animation>();
        _loadingbar_img = _loadingbar.GetComponent<Image>();
        _loading_process_text = _loading_process.GetComponent<Text>();

        _radialprocessbar.SetActive(false);
        _press_action.SetActive(false);
        _loading_process_text.text = "";

        _anim_time = 0;
    }
	
	// Update is called once per frame
	void Update () {

    }

    // Process to open the Chest. Is the Key still inside or is it empty?
    public bool openChest()
    {
        if(isOpen)
        {
            return true;
        }

        //Do's while opening the chest
        progress += 10 * Time.deltaTime;
        _loadingbar_img.fillAmount = progress/10;
        _loading_process_text.text = "" + (int) progress + "/10";
        _radialprocessbar.SetActive(true);

        // Do's when the open-process is done
        if (progress >= 10)
        {
            isOpen = true;
            progress = 15f;
            _radialprocessbar.SetActive(false);
            return true;
        }
        return false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
        {
            
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
        {
            _press_action.SetActive(true);
            _anim_press_action.Play();
            if (_anim_time >= 150)
            {
                _anim_time = 150;
                _press_action.SetActive(false);
                _anim_press_action.Stop();
                return;
            }
            else
            {
                _anim_time += Time.deltaTime + 1;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
        {
            _anim_press_action.Stop();
            _press_action.SetActive(false);
        }
    }
}
