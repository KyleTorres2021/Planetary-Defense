using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEvent_Manager : MonoBehaviour
{
    // Event window to spawn in
    [SerializeField]
    GameObject eventWindow;

    // Declare the list of events that can populate the game
    List<PopupEvent> events;

    // Declared to help track and use the current, active event
    public PopupEvent currentEvent;

    // Declare Singleton
    public static PopupEvent_Manager Instance = null;

    // Called Before Start
    private void Awake()
    {
        // If there is not already an instance of PopupManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize collection of popup events
        events = new List<PopupEvent>();

        // Dummy event
        //events.Add(new PopupEvent_ChangeMoney("You're rich, DUMMY!", "Oh yeah!", "Oh no!", 50000));

        #region standard events
        events.Add(new PopupEvent("Your work is interrupted by a scientist bursting into your office! ''Great news!'' he says ''My team just discovered a meteorite made of precious metals! If we retrieve it," +
            " we could sell it and invest the funds in our planet! Shall I put together a team to collect it?'' \n \n" + "Salvage the meteorite and gain $75?",
            "The scientist's grin stretches from ear to ear. ''Fantastic! I'll get on it right away!''",
            "A look of disbelief comes over the scientist's face. ''What!? WHY!? There's literally no reason to...!'' His protest stops abruptly. ''Very well...'' He sighs.",
            75, 0, false));

        events.Add(new PopupEvent("Your radio suddenly crackles to life as it receives an incoming transmission. ''Hello! I've got an offer for whoever's in charge around here. Seems you're having trouble with" +
            "raiders in these parts. Me and my boys are the best mercenaries in the sector and for a modest fee, we could help clean up around here. Whadya say?''\n \n" + "Hire the Mercenaries? \n -$100, +4 Stability",
            "You can practically hear the smile in the mercenary's voice. ''A pleasure doing business with you. I'll send some of my boys down right away!''",
            "''Hmmph! Very well then. Guess we'll be looking elsewhere for employment.'' With that the somewhat bitter mercenary charts a course for a neighboring system and departs.",
            -100, 4, false));

        events.Add(new PopupEvent("''Pst! Hey you! Over here!'' A voice calls out to you from your office window. Peering outside, you spot a shifty looking man with raider tattoos." +
            "''How'd you like to make a boatload of cash? My mates found an easy score and all you have to do is look the other way.''\n \n" + "Let the raiders perform their heist?\n" +
            "-15 Stability, +$600",
            "''Heheheh... Good choice. You'll hear from me soon.'' With that, the raider disappears into the trees. Later, you recieve an urgent call for backup from a shipping" +
            " vessel docked at the space port-- a request your promptly ignore. That evening, an unmarked envelope arrives for you containing a fat bundle cash.",
            "After you angrily refuse the man's bribe, he beats a hasty retreat! Though your security force is unable to apprehend the raider, you seem to have intimidated his crew into inaction and the " +
            "day passes uneventfully.",
            600, -15, false));

        events.Add(new PopupEvent("The time has come for an appointment the Chief of Security scheduled with you. ''Thank you for seeing me. I'll keep this brief.'' Her expression and tone are cold " +
            "as always. ''My team needs new equipment. Our old gear is getting worn out from use and soon we won't be able to do our jobs. I want money to resuply our defenses.''\n \n" + "-$50, gain 2 stability?",
            "A subtle grin tugs at the corners of her mouth. ''Thank you. I will inform the security force of your decision.''",
            "Her eyes narrow ever so slightly. ''Very well. I will inform the security force of your decision.''",
            -50, 2, false));

        events.Add(new PopupEvent("Word reaches your ear that Science Team has called an emergency meeting. They are requesting the presence of all available government official. Will you attend?",
            "Figuring this must be incredibly important, you set aside time from work and head to the meeting room. There, you find disarray as people discuss how to avert an asteroid on a " +
                "collision course with the planet! You are able to facilitate a plan to slightly alter the asteroid's course through careful use of the Planetary Defense system. It seems your peers' respect " +
                "for you has grown. \n \n +5 Stability",
            "Figuring you have better things to do than listen to Science Team debate how many planets are in this solar system again, you ignore the meeting. You only find out later that there was an asteroid " +
                "headed straight for the planet. Though Science Team has since altered its trajectory, you swear a few scientists are giving you dirty looks in passing.",
            0, 5, false));

        events.Add(new PopupEvent("Word reaches your ear that Science Team has called a meeting. They are requesting the presence of all available government official. Will you attend?",
            "Figuring this must be incredibly important, you set aside time from work and head to the meeting room. There, you find disarray as people discuss whether a small planetoid orbiting around this " +
                "system's star should be classified as a planet or a dwarf planet. To save face, you see the meeting throughto its end and lament the loss of 8 hours.",
            "Figuring you have better things to do than listen to Science Team debate how many planets are in this solar system again, you ignore the meeting.",
            0, 0, false));

        events.Add(new PopupEvent("A letter from a neighboring space colony crosses your desk inquiring about your Planetary Defense system. In this letter, the neighboring governor expresses interest in " +
            "building their own defense system and offers a modest fund in exchange for tower blueprints and skilled technicians to instruct new operators. Will you accept the offer? \n \n +$200",
        "Eager to assist a fellow colony against the raiders (and looking forward to some extra funds,) you contact your neighbor right away. Once you send the requested things, you soon find the promised " +
            "funds wired to your treasury.",
        "Something about this letter strikes you as odd. Feeling like it might be part of a raider scheme to compromise your world's defenses, you decide it should be ignored.",
        200, 0, false));

        events.Add(new PopupEvent("Your radio crackles to life with the sound of a serious man's voice. ''This is the merchant vessel Sakura, requesting permission to land. We're carrying goods from the " +
            "galactic center and wish to do business with the people of your world.\n \n Allow the Sakura to conduct business?",
        "Believing access to these goods might do the people good, you grant the Sakura permission to land. Before long, the Sakura's crew his assembled a sort-of bazaar for people to visit. It seems this " +
            "infusion of new an unusual goods has been a boost to morale.\n \n +2 Stability",
        "Concerned that this may be a trick by the raiders, you decide to play it safe and deny the Sakura permission to land. With some reluctance, the captain agrees to move on, wishing you luck.",
        0, 2, false));

        events.Add(new PopupEvent("The head engineer of the Planetary Defense system just devised a new way to boost the effectiveness of your Resource Towers. He theorizes this breakthrough of his could " +
            "double productivity, though you're not certain the science adds up...\n \n Allow development of improved Resource Towers to proceed?",
        "The end result of this so-called ''Improved Resource Tower Project'' is highly underwhelming to put it mildly. What little resource you gained in the test was almost entirely offset be increased " +
        "energy consumption. At you least you have SOMETHING to show for it, though.\n \n +$15",
        "Not convinced by the engineer's math (he forgot to carry the one!) you decide to forego this.",
        15, 0, false));
        #endregion

        #region Overspend Events
        // Sunbeam
        events.Add(new PopupEvent("Your radio crackles to life with the sound of a cheery man's voice. ''Greetings, this is the merchant vessel Sunbeam, requesting permission to land. We've got deals like you " +
            "wouldn't believe on hardware that could help you with your raider problem. Star Mines, Arrowhead-class fighters, and more! What do you say?'' \n \n Allow the Sunbeam to conduct business on your " +
            "planet?",
        "Believing these weapons could be valuable to your security force, you grant the Sunbeam permission to land. To you shock, the moment the ship sets down, a group of raiders leap from the ship and grab " +
            "everything that isn't nailed down! By the time security arrives, they're long gone...\n \n -$20, -2 Stability",
        "Sensing something is wrong here, you refuse to give the Sunbeam permission to land. Star Mines and Arrowheads on sale, yeah right! That sounds shady at best and an outright lie at worst. Before long, " +
            "the ship departs unceremoniously.",
        -20, -2, true));

        // "Grandma"
        events.Add(new PopupEvent("You hear someone clear their throat over the radio. ''H-Hello Governor-- err, Sweetheart! This is your, uh... Grandmother, here to wish you a " +
        "Happy Birthday! I've got a cake and presents for you, I just need you to give me the shutdown code to the Planetary Defense System in order to deliver them!'' \n \n" + "Give your grandmother the shutdown code?",
    "There is a brief moment of silence before your grandmother speaks up ''Thank you, Honey, I'll see you soon!'' A moment later, you catch another voice hidden in the static. ''Oh my god, I can't " +
        "believe that worked!''\n \n Sadly, your birthday cake never arrives. All you get is a mysterious ''outtage'' of your defenses and a bunch of supplies reported stollen. \n \n -$50, -2 Stability",
    "Considering that you're pretty sure it isn't you birthday, you promptly deny the request and soon hear a group of men arguing with eathother over your radio. ''I TOLD you it wouldn't work!'' One " +
        "says. ''What do you mean you told me, it was YOUR idea!'' The argument continues for close to an hour until law enforcement traces the signal and arrests the would-be criminals.",
        -50, -2, true));

        //Energy Pill
        events.Add(new PopupEvent("It's come to your attention that a new, energy-boosting pill has exploded in popularity on your world. Practically everyone is using it and productivity is up nearly 300%! " +
            " However, you're concened that this new drug is not fully tested.\n \n" + "Allow energy pill sales to continue?",
        "In time, the energy pill's addictive qualities become clear. Efforts to ban the drug have only fueled a thriving black market and your now-former treasurer has put a sizeable dent in your funds in chasing " +
            "his next fix. \n\n -$50, -5 Stability",
        "Despite fierce opposition from citizens of your world and the moans and groans of your colleagues, you're unwilling to put faith in dubious research and soon ban all sales of the energy pill.",
        -50, -5, true));
        #endregion
    }

    /// <summary>
    /// Called to initiate an in-game event
    /// </summary>
    public void BeginEvent()
    {
        //Picks an event and spawns event canvas
        Debug.Log("Event Started");
        SelectCurrentEvent();
        Instantiate(eventWindow);
    }

    void SelectCurrentEvent()
    {
        // Get size of list to aid in selecting a random event
        int listLength = events.Count;

        // Used to select random event
        int random = Random.Range(0, listLength);

        // Set current event to a random event
        currentEvent = events[random];
    }

    
}
