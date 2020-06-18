using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class EnglishEntries : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable Joon;
    public KMSelectable[] JuneFifteenth;
    public KMSelectable[] JuneEleventh;
    public TextMesh Gary;
    public GameObject Jinho;
    public Material[] LetsGoShopping;
    public Material[] Color;
    public Material[] Static;

    private string[][] LoudClapping = new string[10][] {
      new string[7]{"Let’s go\nshopping!","When?","How about...\ntomorrow?","Tomorrow?","Sorry,\nI can’t.","Then how\nabout\nthis Sunday?","No problem\nhahaha."},
      new string[10]{"What’s that?","I have\nno idea.","Try this.","Hmmmm...it’s\nan egg.","I like\nvery much.","*coughs up\nblood*","Can I have\nsome water?","Here you are.","Thank you.","You are\nwelcome."},
      new string[7]{"Welcome!","Thank you\nfor inviting me!","You can take\noff your coat.","Thanks!","Oh, don’t take\noff your shoes.","We wear\nour shoes\nin the house.","Oh, I see."},
      new string[7]{"Where’s my\npencil?","Is this\nyour pencil?","No, mine is\nlonger than\nthat.","Is this\nyour pencil?","No, my pencil\nis longer\nthan that.","Look, that’s\nyour pencil!","AUGH!"},
      new string[12]{"*Ann plays Partita\nD minor BWV 1004 by\nJS Bach (1720) on\nthe violin*","(Kevin starts\nto clap)","(Kevin\nescalates the\nsituation by\napproaching\nAnn)","(Kevin starts\nto clap faster)","You are great. ","When is your\nviolin concert?","June 15th.","What’s the\nday today?","June 11th.","Oh!\nThis Friday?","Can you come\nto my concert?","Sure!"},
      new string[6]{"MMMMM","MMMMMMMM","MMMMMM\nMMMMMMM","Good morning.","Can you\nhelp me?","Sure, I can."},
      new string[6]{"Hi Ann!\nHow’s it going?","Not bad.\nHow about\nyou?","Fine.","See you later.","See ya.","Ann, wait!"},
      new string[2]{"Help me,\nplease!","Wait!\nI’m coming!"},
      new string[7]{"What a\nbeautiful day!","Do you\nlike spring?","Yes, I do!","I like spring!\nIt’s nice\nand warm.","I like summer.","Summer?\nIt’s too hot!","Right, but we\nhave a long\nvacation!"},
      new string[7]{"This is\nmy house!","Wow! It’s great!","Thanks!","This is\nthe living room!","Wonderful!","This is\nthe bedroom.","What a\nnice house!"}
    };
    string[] LogTitle = {"Let's Go Shopping","It's an Egg","We Don't Take Off Our Shoes","Ann's Revenge Blossoms","Kevin Claps for Ann","Tony Can't Cut Bread","Kevin Makes Ann Uncomfortable","Tony and the Cookie Jar","Peter Talks Like a Girl","Ann's House"};
    int[] ThatWasGreat = {6969,6969,6969,6969,6969,6969,6969,6969};
    int Sure = 0;
    int Ann = 0;
    int Kevin = 0;
    int Need = 0;
    int SingleNote = 0;
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake() {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable ViolinConcert in JuneFifteenth) {
            ViolinConcert.OnInteract += delegate () { ViolinConcertPress(ViolinConcert); return false; };
        }
        foreach (KMSelectable Today in JuneEleventh) {
            Today.OnInteract += delegate () { TodayPress(Today); return false; };
        }
        Joon.OnInteract += delegate () { JoonPress(); return false; };
    }

    void Start() {
      Ann = (UnityEngine.Random.Range(0,LoudClapping.Count()));
      Kevin = UnityEngine.Random.Range(0,LoudClapping[Ann].Count());
      Need = UnityEngine.Random.Range(0,2);
      System.DateTime curTime = System.DateTime.Now;
      if (curTime.Month == 6 && (curTime.Day == 11 || curTime.Day == 15)) {
        Ann = 4;
      }
      Debug.LogFormat("[English Entries #{0}] The phrase is {1}. This is from the episode {2}.", moduleId, LoudClapping[Ann][Kevin].Replace("\n"," "), LogTitle[Ann]);
      Gary.text = LoudClapping[Ann][Kevin];
      ThatWasGreat[0] = (Ann * 3) + Need;
      for (int i = 1; i < 8; i++) {
        ThatWasGreat[i] = UnityEngine.Random.Range(0,LoudClapping.Count());
        while (ThatWasGreat[i] == Ann) {
          ThatWasGreat[i] = UnityEngine.Random.Range(0,LoudClapping.Count());
        }
        ThatWasGreat[i] = ThatWasGreat[i] * 3 + UnityEngine.Random.Range(0,3);
      }
      for (int i = 1; i < 8; i++) {
        for (int j = 0; j < 8; j++) {
          while (ThatWasGreat[i] / 3 == ThatWasGreat[j] / 3 && j != i) {
            ThatWasGreat[i] -= 1;
            if (ThatWasGreat[i] < 0) {
              ThatWasGreat[i] = LetsGoShopping.Count() - 1;
            }
          }
        }
        while (ThatWasGreat[i] / 3 == ThatWasGreat[0] / 3) {
          ThatWasGreat[i] = UnityEngine.Random.Range(0,LoudClapping.Count()) * 3 + UnityEngine.Random.Range(0,3);
        }
      }

      ThatWasGreat.Shuffle();
    }
    void JoonPress(){
      Joon.AddInteractionPunch();
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Joon.transform);
      if (ThatWasGreat[Sure] == (Ann * 3) + Need) {
        Audio.PlaySoundAtTransform("YouAreGreat", transform);
        SingleNote = 2;
        Debug.LogFormat("[English Entries #{0}] You submitted the correct frame, module disarmed. You are great!", moduleId);
      }
      else {
        GetComponent<KMBombModule>().HandleStrike();
        Debug.LogFormat("[English Entries #{0}] You submitted the incorrect frame, strike. Kevin walks in on Ann playing the stringy paddle. She is no virtuoso. Kevin makes light of the fact by asking when her concert is. She replies with great sarcasm that it's 4 days away. Kevin is confused. Ever since that last binge, his short term memory has been shaken. He cannot remember what day it is, who he is talking to, or why. He suddenly regains consciousness, and tells Ann that it's Friday. She agrees out of a fear of being wrong. She is possibly more confused than him. She asks if he can come to her concert. She has a string she'd like to wrap around his neck, but she doesn't tell him this. He replies, sarcastically, that he'd love to. Even with the memory loss, he knows he would be stepping into a death trap. The tension is so thick, you could cut it, but only if you had a diamond blade saw, or the jaws of life. For reference, that is picture {1}.", moduleId, ThatWasGreat[Sure]);
        Audio.PlaySoundAtTransform("AwesomeViolin", transform);
      }
    }
    void ViolinConcertPress(KMSelectable ViolinConcert) {
      if (ViolinConcert == JuneFifteenth[0]) {
        if (SingleNote == 1) {
          SingleNote = 0;
        }
      }
      else if (ViolinConcert == JuneFifteenth[1]) {
        if (SingleNote == 0) {
          SingleNote = 1;
        }
      }
    }
    void TodayPress(KMSelectable Today) {
      if (Today == JuneEleventh[0] && SingleNote == 1) {
        StartCoroutine(MMMMMMMMMMMMM());
      }
      else if (Today == JuneEleventh[1] && SingleNote == 1) {
        StartCoroutine(MMMMMMMMMMMMMM());
      }
    }
    void Update(){
      if (SingleNote == 1) {
        Jinho.GetComponent<MeshRenderer>().material = LetsGoShopping[ThatWasGreat[Sure]];
        Gary.text = "";
      }
      else if (SingleNote == 0) {
        Jinho.GetComponent<MeshRenderer>().material = Color[0];
        Gary.text = LoudClapping[Ann][Kevin];
      }
      else if (SingleNote == 2 && moduleSolved == false) {
        moduleSolved = true;
        GetComponent<KMBombModule>().HandlePass();
        SingleNote = 2;
        Jinho.GetComponent<MeshRenderer>().material = Color[1];
        Gary.text = "";
      }
    }
    IEnumerator MMMMMMMMMMMMM(){
      Audio.PlaySoundAtTransform("Why", transform);
      for (int i = 0; i < 10; i++) {
        Jinho.GetComponent<MeshRenderer>().material = Static[i];
        yield return new WaitForSecondsRealtime(.02f);
      }
      if (Sure == 0) {
        Sure = 7;
      }
      else {
        Sure -= 1;
      }
    }
    IEnumerator MMMMMMMMMMMMMM(){
      Audio.PlaySoundAtTransform("Why", transform);
      for (int i = 0; i < 10; i++) {
        Jinho.GetComponent<MeshRenderer>().material = Static[i];
        yield return new WaitForSecondsRealtime(.02f);
      }
      if (Sure == 7) {
        Sure = 0;
      }
      else {
        Sure += 1;
      }
    }
    //I add the twitch play
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} VOL up/down to interact with the volume buttons, CH up/down to change the channel, and Submit to submit the current frame.";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command){
      if (Regex.IsMatch(command, @"^\s*Submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) {
        yield return null;
        JoonPress();
        yield break;
      }
      command = command.Trim();
      string[] parameters = command.Split(' ');
        if (parameters.Length > 2) {
          yield return null;
          yield return "sendtochaterror Too many words";
          yield break;
        }
        else if (parameters.Length == 2) {
          yield return null;
          if (parameters[0].ToUpper() == "VOL") {
            if (parameters[1].ToLower() == "up") {
              JuneFifteenth[1].OnInteract();
            }
            else if (parameters[1].ToLower() == "down") {
              JuneFifteenth[0].OnInteract();
            }
            else {
              yield return "sendtochaterror Invalid command.";
              yield break;
            }
          }
          else if (parameters[0].ToUpper() == "CH") {
            if (parameters[1].ToLower() == "up") {
              JuneEleventh[1].OnInteract();
            }
            else if (parameters[1].ToLower() == "down") {
              JuneEleventh[0].OnInteract();
            }
            else {
              yield return "sendtochaterror Invalid command.";
              yield break;
            }
          }
          else {
            yield return "sendtochaterror Invalid command.";
            yield break;
          }
        yield break;
      }
      else if (parameters.Length < 2) {
        yield return null;
        yield return "sendtochaterror Not enough commands";
        yield break;
      }
    }
}
