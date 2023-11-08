using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;


namespace Hogwarts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the game data
            Load load = new Load();
            string? gameData = load.gameData;

            // If gameData is not null, it means there is saved game data
            if (gameData != null)
            {
                // Split the gameData string into fname and lname
                string[] names = gameData.Split(',');
                string fname = names[0];
                string lname = names[1];

                // Print the loaded names
                Console.WriteLine("Loaded names: " + fname + " " + lname);
            }
            else
            {
                // If gameData is null, it means there is no saved game data
                // So, create a new Acceptence_letter
                Acceptence_letter letter = new Acceptence_letter();
            }
        }

        class Scenes
        {
            HogwartsExpress  Express;
            Acceptence_letter letter;

            public Scenes()
            {
                letter = new Acceptence_letter();
            }
        }

        class HogwartsExpress
        {
            public HogwartsExpress()
            {
                Console.WriteLine("");
            }
        }

        class Acceptence_letter
        {
        public string? fname { get; private set; }
        public string? lname { get; private set;}

        public void SaveNames()
        {
            string gameData = fname + ", " + lname;
            Save save = new Save(gameData);
        }
        
        public Acceptence_letter()
        {
            Console.WriteLine(@"
        HOGWARTS SCHOOL of WITCHCRAFT and WIZARDRY
    Headmaster: Albus Dumbledore
    (Order of Merlin, First Class, Grand Sorc., Chf. Warlock,
    Supreme Mugwump, International Confed. of Wizards)
                ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter your first name");
            Console.ResetColor();
            Console.Write("Dear ");
            string? fname = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
        HOGWARTS SCHOOL of WITCHCRAFT and WIZARDRY
    Headmaster: Albus Dumbledore
    (Order of Merlin, First Class, Grand Sorc., Chf. Warlock,
    Supreme Mugwump, International Confed. of Wizards)
                ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter your surname");
            Console.ResetColor();
            Console.Write("Dear " + fname + " ");
            string? lname = Console.ReadLine();
            SaveNames();
            Console.Clear();
            Console.WriteLine(@"
        HOGWARTS SCHOOL of WITCHCRAFT and WIZARDRY
    Headmaster: Albus Dumbledore
    (Order of Merlin, First Class, Grand Sorc., Chf. Warlock,
    Supreme Mugwump, International Confed. of Wizards)
                ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dear " + fname + " " + lname + ",");
            Console.WriteLine();  
            Console.WriteLine(@"
    We are pleased to inform you that you have been accepted at Hogwarts School
    of Witchcraft and Wizardry. Please find enclosed a list of all necessary books
    and equipment.
                ");
            Console.WriteLine("Term begins on 1 September. We await your owl by no later than 31 July");
            Console.WriteLine();
            Console.WriteLine("Yours sincerely,");
            Console.WriteLine();
            Console.WriteLine("Minerva McGonagall");
            Console.WriteLine("Deputy Headmistress");
            Console.Write("Press [ENTER] for next page ...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
        HOGWARTS SCHOOL of WITCHCRAFT and WIZARDRY
    Headmaster: Albus Dumbledore
    (Order of Merlin, First Class, Grand Sorc., Chf. Warlock,
    Supreme Mugwump, International Confed. of Wizards)
            ");
            Console.WriteLine(@"


First-year students will require:

    1. Three sets of plain work robes (black)
    2. One plain pointed hat (black) for day wear
    3. One pair of protective gloves (dragon hide or similar)
    4. One winter cloak (black, with silver fastenings)
    Please note that all pupil's clothes should carry name tags.


All students should have a copy of each of the following:

    The Standard Book of Spells (Grade 1) by Miranda Goshawk
    A History of Magic by Bathilda Bagshot
    Magical Theory by Adalbert Waffling
    A Beginner's Guide to Transfiguration by Emeric Switch
    One Thousand Magical Herbs and Fungi by Phyllida Spore
    Magical Drafts and Potions by Arsenius Jigger
    Fantastic Beasts and Where to Find Them by Newt Scamander
    The Dark Forces: A Guide to Self-Protection by Quentin Trimble

            ");
            Console.Write("Press [ENTER] for next page ...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(@"
        HOGWARTS SCHOOL of WITCHCRAFT and WIZARDRY
    Headmaster: Albus Dumbledore
    (Order of Merlin, First Class, Grand Sorc., Chf. Warlock,
    Supreme Mugwump, International Confed. of Wizards)
            ");
            Console.WriteLine(@"


Other equipment:

    1 wand
    1 cauldron (pewter, standard size 2)
    1 set glass or crystal phials
    1 telescope
    1 set brass scales

Students may also bring, if they desire, an owl or a cat or a toad.
Parents are reminded that first years are not allowed thier own broomstick

Yours sincerely,

Lucinda Thomsonicle-Pocus
Chief Attendant of Witchcraft Provisions
            ");


        }
        }


    }
 class Save
{
    public Save(string gameData) // saving game data
    {
        string path = ".Config/saves/save.dat"; 

        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            writer.Write(gameData);
        }
    }
}

class Load
{
    public string? gameData { get; private set; }

    public Load()
    {
        string? gameData = ""; // Initialize gameData to null
        string path = ".Config/saves/save.dat";
        if (File.Exists(path))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                gameData = reader.ReadString();
            }
        }
    }
}
}   
