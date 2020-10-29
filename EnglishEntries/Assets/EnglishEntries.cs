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

    int[] ThatWasGreat = new int[8];
    int Sure;
    int Ann;
    int Kevin;
    int Need;
    int SingleNote;

    private string[][] LoudClapping = new string[30][] {
      new string[6]{"Let’s go\nshopping!","When?","How about...\ntomorrow?","Tomorrow?","Then how\nabout\nthis Sunday?","No problem\nhahaha."},
      new string[9]{"What’s that?","I have\nno idea.","Try this.","Hmmmm...it’s\nan egg.","I like\nvery much.","*coughs up\nblood*","Can I have\nsome water?","Thank you.","You are\nwelcome."},
      new string[5]{"Welcome!","Thank you\nfor inviting me!","You can take\noff your coat.","Oh, don’t take\noff your shoes.","We wear\nour shoes\nin the house."},
      new string[6]{"Where’s my\npencil?","No, mine is\nlonger than\nthat.","Is this\nyour pencil?","No, my pencil\nis longer\nthan that.","Look, that’s\nyour pencil!","AUGH!"},
      new string[12]{"*Ann plays Partita\nD minor BWV 1004 by\nJS Bach (1720) on\nthe violin*","(Kevin starts\nto clap)","(Kevin\nescalates the\nsituation by\napproaching\nAnn)","(Kevin starts\nto clap faster)","You are great. ","When is your\nviolin concert?","June 15th.","What’s the\nday today?","June 11th.","Oh!\nThis Friday?","Can you come\nto my concert?","Sure!"},
      new string[6]{"MMMMM","MMMMMMMM","MMMMMM\nMMMMMMM","Good morning.","Can you\nhelp me?","Sure, I can."},
      new string[5]{"Hi Ann!\nHow’s it going?","Fine.","See you later.","See ya.","Ann, wait!"},
      new string[2]{"Help me,\nplease!","Wait!\nI’m coming!"},
      new string[7]{"What a\nbeautiful day!","Do you\nlike spring?","Yes, I do!","I like spring!\nIt’s nice\nand warm.","I like summer.","Summer?\nIt’s too hot!","Right, but we\nhave a long\nvacation!"},
      new string[6]{"This is\nmy house!","Wow! It’s great!","This is\nthe living room!","Wonderful!","This is\nthe bedroom.","What a\nnice house!"},
      new string[4]{"What is\nNamsu doing?","He is making\nhamburgers.","Really? Let’s\ngo and help him.","Mmmmmmmm.\nDelicious!"},
      new string[7]{"Hello! I’m\nJinho! Nice\nto meet you.","Nice to meet\nyou Jinho, I’m\nCindy!","Where are you\nfrom Cindy?","I’m from\nAustralia.","Where’s your\nroom?","It’s on the\nfirst floor.","Oh, my room\nis on the\nfirst floor\ntoo."},
      new string[4]{"Look! That’s\nmy uncle.","What?","That’s my\nuncle, he’s a\nsinger.","Oh, he has\na long hair!"},
      new string[6]{"When is your\nbirthday?","December 25th.","Oh, Christmas\nis your\nbirthday!","When is\nyours, Nami?","September 10.","I’m older\nthan you."},
      new string[6]{"Where is\nmy sock?","Is this\nyours?","No. It’s\nnot mine.","Mine is\nred.","Whose sock\nis this?","Yes. It’s\nmine."},
      new string[6]{"Hi Ann!\nNice to\nsee you again.","Hi Nami!\nWhat did\nyou do\nthis holiday?","I went\nskating with\nmy family.","Sounds good.","How about\nyou, Ann?","I stayed\nhome and\nlistened to\nmusic."},
      new string[6]{"Hi Bill!\nLet’s play\nbasketball!","Sounds great!","Can you join\nus, Joon?","Sure! I\nlike basketball.","Me too.\nLet’s go!","Ok."},
      new string[3]{"Where’s your\nsister?","She’s over\nthere.","Oh! She\nis tall\nand pretty."},
      new string[5]{"Let’s sing.","I don’t\nwant to\nsing.","What do\nyou want\nto do?","I want\nto play\ncomputer games.","Ok! That’s\na good idea!"},
      new string[9]{"Time to\nsay goodbye\nNami!","Are you\ngoing back\nto New\nYork?","Yes, I am.\nGoodbye Jinho!\nGoodbye Nami!","Take care,\nKevin! We’ll\nmiss you!","I’ll miss\nyou too.","So long\neveryone!","I love\nyou all.","See you,\nNami.","See you\nagain."},
      new string[6]{"Let’s play\nsoccer this\nafternoon.","Why?","Because I’m\nsick. I\nhave a\nheadache.","Oh, that’s\ntoo bad.","Get some\nrest.","OK, I will."},
      new string[5]{"Ann, where\nare you?","I’m here.","What are\nyou doing?","I’m cleaning\nyour shoes.","Good girl."},
      new string[6]{"Look up\nthere!","It’s very\ntall!","What a\ntall tower!","Let’s go\nup there.","Can we go\nup there?","Of course!\nWe can use\nthe elevator."},
      new string[14]{"Hello! This\nis Paul.","Hi Paul!\nHow is it\ngoing?","Good.\nVery good.","Is it\nfall there?","Yes. It is.\nCan you\nsee the\nleaves?","Oh, yes!\nBeautiful!","Do you\nlike fall?","Yes. I do.\nI like\nfall.","How about\nyou?","I like\nspring.","It’s warm\nand nice.","It’s spring\nhere, Paul.","Beautiful flowers\nare everywhere\nnow.","Oh, beautiful."},
      new string[6]{"What will\nyou do\nthis summer?","I will go\non a trip.","Sounds\nwonderful!\nWhere?","To Busan.\nWhat will\nyou do?","I’ll just\nplay badminton,\nbasketball, soccer.","It sounds\ngood."},
      new string[8]{"Can I\nhelp you?","Yes, please.","I want to\nbuy some\nflowers.","How about\nthis one?","Oh, it’s\nbeautiful!","How much\nis it?","It’s fourteen\ndollars.","Ok, I’ll\ntake it."},
      new string[10]{"Look at\nthe police\nofficer!","He is\nvery nice!","Yes!\nHe is!","My father\nis a police\nofficer.","Police officer?","It’s great.","I want to\nbe a police\nofficer.","What does\nyour father\ndo?","He’s a\npilot.","Wow! I\nwant to\nbe a pilot."},
      new string[7]{"Does your\nmother work?","Yes, she\ndoes.","She is\na cook.","That’s\ngreat!","Does your\nmother work\ntoo?","Yes. She\nis a teacher.","That’s great!"},
      new string[5]{"What are\nyou doing?","We’re making\na model\nplane.","Is it fun?","Sure. Would\nyou like\nto join\nus?","Yes! I’d\nlove to."},
      new string[5]{"Tomorrow is\nMom’s birthday.","What do\nyou want to\ndo for Mom?","I want to\nmake a card.","How about\nyou?","I want to\ncook for Mom."}
    };
    string[] LogTitle = {"Let's Go Shopping","It's an Egg","We Don't Take Off Our Shoes","Ann's Revenge Blossoms","Kevin Claps for Ann","Tony Can't Cut Bread","Kevin Makes Ann Uncomfortable","Tony and the Cookie Jar","Peter Talks Like a Girl","Ann's House","Making Hamburgers","Cindy Hits on Jinho","Jinho's Uncle is a Cartoon","September 10","Joon Lost His Sock","Ann Listened to Music All Winter Vacation","Poor Kevin","Joon is a Little Creepy","Jingo is Too Happy","Kevin is Going Back to New York","Jinho Has a Headache","Ann Shines Her Dad's Shoes","Peter Mails it in","Paul Talks Like a Girl","Kevin and Ann Mock Each Other on the Playground","Kevin Buys Opium","Ann and Kevin Have a Showdown","Ann and Joon Imagine Parents","Ann, Jinho, and Nami Plan to Destroy the Earth","Nami’s Little Brother Thinks Filial Is Something You Eat"};

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable ViolinConcert in JuneFifteenth) {
            ViolinConcert.OnInteract += delegate () { ViolinConcertPress(ViolinConcert); return false; };
        }
        foreach (KMSelectable Today in JuneEleventh) {
            Today.OnInteract += delegate () { TodayPress(Today); return false; };
        }
        Joon.OnInteract += delegate () { JoonPress(); return false; };
    }

    void Start () {
      Ann = UnityEngine.Random.Range(0,LoudClapping.Count());
      Kevin = UnityEngine.Random.Range(0,LoudClapping[Ann].Count());
      Need = UnityEngine.Random.Range(0,3);
      DateTime curTime = DateTime.Now;
      if (curTime.Month == 6 && (curTime.Day == 11 || curTime.Day == 15))
        Ann = 4;
      Debug.LogFormat("[English Entries #{0}] The phrase is \"{1}\" This is from the episode {2}.", moduleId, LoudClapping[Ann][Kevin].Replace("\n"," "), LogTitle[Ann]);
      Gary.text = LoudClapping[Ann][Kevin];
      ThatWasGreat[0] = (Ann * 3) + Need;
      for (int i = 1; i < 8; i++) {
        ThatWasGreat[i] = UnityEngine.Random.Range(0,LoudClapping.Count());
        while (ThatWasGreat[i] / 3 == Ann) {
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
    void JoonPress () {
      Joon.AddInteractionPunch();
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Joon.transform);
      if (ThatWasGreat[Sure] == (Ann * 3) + Need) {
        Audio.PlaySoundAtTransform("YouAreGreat", transform);
        if (SingleNote != 2)
        {
          SingleNote = 2;
          Debug.LogFormat("[English Entries #{0}] You submitted the correct frame, module disarmed. You are great!", moduleId);
        }
      }
      else {
        GetComponent<KMBombModule>().HandleStrike();
        Debug.LogFormat("[English Entries #{0}] You submitted the incorrect frame, strike. Kevin walks in on Ann playing the stringy paddle. She is no virtuoso. Kevin makes light of the fact by asking when her concert is. She replies with great sarcasm that it's 4 days away. Kevin is confused. Ever since that last binge, his short term memory has been shaken. He cannot remember what day it is, who he is talking to, or why. He suddenly regains consciousness, and tells Ann that it's Friday. She agrees out of a fear of being wrong. She is possibly more confused than him. She asks if he can come to her concert. She has a string she'd like to wrap around his neck, but she doesn't tell him this. He replies, sarcastically, that he'd love to. Even with the memory loss, he knows he would be stepping into a death trap. The tension is so thick, you could cut it, but only if you had a diamond blade saw, or the jaws of life. For reference, that is picture {1}. This is from episode {2}.", moduleId, ThatWasGreat[Sure], LogTitle[Sure / 3]);
        Audio.PlaySoundAtTransform("AwesomeViolin", transform);
      }
    }
    void ViolinConcertPress (KMSelectable ViolinConcert) {
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
      if (Sure == 0)
        Sure = 7;
      else
        Sure -= 1;
    }
    IEnumerator MMMMMMMMMMMMMM(){
      Audio.PlaySoundAtTransform("Why", transform);
      for (int i = 0; i < 10; i++) {
        Jinho.GetComponent<MeshRenderer>().material = Static[i];
        yield return new WaitForSecondsRealtime(.02f);
      }
      if (Sure == 7)
        Sure = 0;
      else
        Sure += 1;
    }

    //I add the twitch play
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} VOL up/down to interact with the volume buttons, !{0} CH up/down to change the channel, and !{0} Submit to submit the current frame.";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command){
      if (Regex.IsMatch(command, @"^\s*Submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) {
        yield return null;
        JoonPress();
        yield break;
      }
      command = command.Trim();
      string[] parameters = command.Split(' ');
      yield return null;
        if (parameters.Length > 2) {
          yield return "sendtochaterror Too many words";
          yield break;
        }
        else if (parameters.Length == 2) {
          if (parameters[0].ToUpper() == "VOL") {
            if (parameters[1].ToLower() == "up")
              JuneFifteenth[1].OnInteract();
            else if (parameters[1].ToLower() == "down")
              JuneFifteenth[0].OnInteract();
            else {
              yield return "sendtochaterror Invalid command.";
              yield break;
            }
          }
          else if (parameters[0].ToUpper() == "CH") {
            if (parameters[1].ToLower() == "up")
              JuneEleventh[1].OnInteract();
            else if (parameters[1].ToLower() == "down")
              JuneEleventh[0].OnInteract();
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
        yield return "sendtochaterror Not enough commands";
        yield break;
      }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        if (ThatWasGreat[Sure] == (Ann * 3) + Need)
        {
            Joon.OnInteract();
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            if (SingleNote != 1)
            {
                JuneFifteenth[1].OnInteract();
                yield return new WaitForSeconds(0.1f);
            }
            int ct = Sure;
            int ct2 = Sure;
            int[] counts = new int[2];
            while (ct != Array.IndexOf(ThatWasGreat, (Ann * 3) + Need))
            {
                ct++;
                if (ct > 7)
                    ct = 0;
                counts[1]++;
            }
            while (ct2 != Array.IndexOf(ThatWasGreat, (Ann * 3) + Need))
            {
                ct2--;
                if (ct2 < 0)
                    ct2 = 7;
                counts[0]++;
            }
            if (counts[0] > counts[1])
            {
                for (int i = 0; i < counts[1]; i++)
                {
                    JuneEleventh[1].OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else if (counts[0] < counts[1])
            {
                for (int i = 0; i < counts[0]; i++)
                {
                    JuneEleventh[0].OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                int rand = UnityEngine.Random.Range(0, 2);
                for (int i = 0; i < counts[rand]; i++)
                {
                    JuneEleventh[rand].OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
            }
            while (ThatWasGreat[Sure] != (Ann * 3) + Need) { yield return null; }
            Joon.OnInteract();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
