using System;
using System.IO;


    
    public class PersonTest
    {
    
    public static void Main(string[] args)
        {
            Person[] objectPerson = new Person[1];
            string choice;

            do
            {
                Console.WriteLine("*************");
                Console.WriteLine("Am start immer die Option (a) enigeben, um die Daten zu laden");
                Console.WriteLine("*************");
                Console.WriteLine("HAUPTMENU:");
                Console.WriteLine("----------");
                Console.WriteLine("Optionen:");
                Console.WriteLine("***Person erfassen (1):");
                Console.WriteLine("***Alle erfassten Personen anzeigen (2):");
                Console.WriteLine("***Anzahl erfasste Personen anzeigen (3):");
                Console.WriteLine("***Person mit Vor-/Nachname/Email suchen (4):");               
                Console.WriteLine("***Programm beenden (q):");
                Console.WriteLine("Option:");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "a":
                        Load(ref objectPerson);
                        break;
                    
                    case "1":
                    AddPerson(ref objectPerson);
                        break;
                    case "2":
                    Display(objectPerson);
                        break;
                    case "3":
                        LoadData(ref objectPerson);
                        break;
                    case "4":
                    search(ref objectPerson);
                        break;
                    default:
                        break;
                }
               Console.Clear();
            } while (choice != "q");
        }

    public static void Load(ref Person[] objectPerson)
    {

        StreamReader reader = new StreamReader("daten.txt");
        int size = Convert.ToInt32(reader.ReadLine());
        objectPerson = new Person[size];
        Console.WriteLine("Daten wurden geladen. ");


        for (int i = 0; i < objectPerson.Length; i++)
        {
            objectPerson[i] = new Person();
            objectPerson[i].Namen = reader.ReadLine();
            objectPerson[i].Vornamee = reader.ReadLine();
            objectPerson[i].emails = reader.ReadLine();
            objectPerson[i].handys = reader.ReadLine();
            
        }
        reader.Close();

        Console.ReadKey();
    }
    public static void LoadData(ref Person[] objectPerson)
        {

            StreamReader reader = new StreamReader("daten.txt");
            int size = Convert.ToInt32(reader.ReadLine());
            objectPerson = new Person[size];
            Console.WriteLine("Es wurden {0} Personen geladen ",size);
            

            for (int i = 0; i < objectPerson.Length; i++)
            {
                objectPerson[i] = new Person();
                objectPerson[i].Namen = reader.ReadLine();
                objectPerson[i].Vornamee = reader.ReadLine();
                objectPerson[i].emails = reader.ReadLine();
                objectPerson[i].handys = reader.ReadLine();

            }
            reader.Close();
            
            Console.ReadKey();
        }
       
    
        public static void Display(Person[] objectPerson)
        {
        Console.Clear();
         for(int i = 0; i < objectPerson.Length; i++)
            {
                objectPerson[i].DisplayInformation();
            }
        Console.WriteLine("press any key to return to Menu...");
        Console.ReadKey();
        }
        
        public static void AddPerson(ref Person[] objectPerson)
        {
        StreamWriter writer = new StreamWriter("daten.txt");
        writer.WriteLine(objectPerson.Length + 1);
        Person temp = new Person();

        Console.Write("Geben Sie Ihren Namen ein:     ");
        temp.Namen = Console.ReadLine();

        Console.Write("Geben Sie Ihren Vornamen ein:  ");
        temp.Vornamee = Console.ReadLine();

        Console.Write("Geben Sie Ihre Email ein:      ");
        temp.emails = Console.ReadLine();

        Console.Write("Geben Sie Ihre Handynummer ein:");
        temp.handys = Console.ReadLine();


            writer.WriteLine(temp.Namen);
            writer.WriteLine(temp.Vornamee);
            writer.WriteLine(temp.emails);
            writer.WriteLine(temp.handys);


        //daten override, durch loop verhindern.
        
        for(int i = 0; i < objectPerson.Length; i++)
        {
            writer.WriteLine(objectPerson[i].Namen);
            writer.WriteLine(objectPerson[i].Vornamee);
            writer.WriteLine(objectPerson[i].emails);
            writer.WriteLine(objectPerson[i].handys);
        }
        writer.Close();

        LoadData(ref objectPerson);
        }
        public static string namen1,vorname1,wahl,mail1;
       
        public static void search(ref Person[] objectPerson)
        {
        
            Console.WriteLine("Wollen Sie nach dem 'Namen','Vornamen' oder 'Mail' suchen.");//Index auf alle Arrays umstellen!
            wahl = Console.ReadLine();

            switch (wahl)
            {
                case "Namen":
                    Console.WriteLine("Geben Sie den Namen ein:");
                    namen1 = Console.ReadLine();   
                    for (int i = 0; i < objectPerson.Length;i ++)
                    if (objectPerson[i].Namen == namen1)
                    {
                        objectPerson[i].DisplayInformationI(ref objectPerson);
                        Console.ReadLine();
                        
                    }
                    /*else
                    {
                        Console.WriteLine("N / A");
                        Console.ReadLine();
                        return;
                    }*/
                    break;
                case "Vornamen":
                    Console.WriteLine("Geben Sie den Vornamen ein:");
                    vorname1 = Console.ReadLine();
                    for (int i = 0; i < objectPerson.Length; i++)
                    if (objectPerson[i].Vornamee == vorname1)
                    {
                        objectPerson[i].DisplayInformationI(ref objectPerson);
                        Console.ReadLine();
                        return;
                    }
                    /*else
                    {
                        Console.WriteLine("N / A");
                        Console.ReadLine();
                    }*/
                    break;
                case "Mail":
                    Console.WriteLine("Geben Sie die E-Mail ein");
                    mail1 = Console.ReadLine();
                    for (int i = 0; i < objectPerson.Length; i++)
                    if (objectPerson[i].emails == mail1)
                    {
                        objectPerson[i].DisplayInformationI(ref objectPerson);
                        Console.ReadLine();
                        return;
                    }
                    /*else
                    {
                        Console.WriteLine("N / A");
                        Console.ReadLine();
                    }*/
                    break;
                default:
                    break;
                







            }
            return;
        
    }

}
       


       
    

    public class Person
    {
        public string Name;
        public string Vorname;
        public string mail;
        public string handy;

        public string Namen
        {
            get { return Name; }
            set { Name = value; }
        }
        public string Vornamee
        {
            get { return Vorname; }
            set { Vorname = value; }

        }
        public string emails
        {
            get { return mail; }
            set { mail = value; }

        }
        public string handys
        {
            get { return handy; }
            set { handy = value;}
        }
        public Person()
        {
            Name = "Beispiel";
            Vorname = "John Doe";
            mail = "muster@huol.de";
            handy = "00012341234";
        }
        
        public void DisplayInformationI(ref Person[] objectPerson)
        {
        Console.WriteLine("| Namen  : {0}", Namen);
        Console.WriteLine("| Vorname: {0}", Vornamee);
        Console.WriteLine("| EMail  : {0}", emails);
        Console.WriteLine("| Handy  : {0}", handys);
        Console.WriteLine("---------------------------");
    }
        public void DisplayInformation()
        {
        
            Console.WriteLine("| Namen  : {0}", Namen);
            Console.WriteLine("| Vorname: {0}", Vornamee);
            Console.WriteLine("| EMail  : {0}", emails);
            Console.WriteLine("| Handy  : {0}", handys);
            Console.WriteLine("---------------------------");
            
        }
    }



