using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static public List<Character> characters;
    static public List<Wizard> wizards;
    static public Queue<Artifact> artifacts;


    static public void CreateCharacter()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите рассу: ");
        string race = Console.ReadLine();
        Console.Write("Введите гендер: ");
        characters.Add(new Character(name, race, Console.ReadLine()));
    }

    static public void CreateWizard()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите рассу: ");
        string race = Console.ReadLine();
        Console.Write("Введите гендер: ");
        string gender = Console.ReadLine();
        Console.Write("Введиет максимальную ману: ");
        int maxMana = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введиет нешнюю ману: ");
        wizards.Add(new Wizard(name, race, gender, maxMana, Convert.ToInt32(Console.ReadLine())));
    }

    static public void PrintCharacters() 
    {
        Console.WriteLine("СОЗДАННЫЕ ГЕРОИ:");
        int i = 0;
        foreach(Character ch in characters){
            Console.WriteLine(i + " - " + ch.ToString());
            i++;
        }
    }

    static public void PrintWizards() 
    {
        Console.WriteLine("СОЗДАННЫЕ ВОЛШЕБНИКИ:");
        int i = 0;
        foreach(Wizard wiz in wizards){
            Console.WriteLine(i + " - " + wiz.ToString());
            i++;
        }
    }

    static public Character GetCaracter() 
    {
        PrintCharacters();
        Console.Write("\nВведите индекс героя: ");
        return characters[Convert.ToInt32(Console.ReadLine())];
    }

    static public Wizard GetWizard() 
    {
        PrintWizards();
        Console.Write("\nВведите индекс волшебника: ");
        return wizards[Convert.ToInt32(Console.ReadLine())];
    }

    static public int ChoosePlayer(){
        Console.Write("Выберите игрока(1-герой, 2-волшебник): ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            return 1;

            case 2:
            return 2;

            default:
            {
                Console.WriteLine("Нет такого варианта ответа");
                ChoosePlayer();
                throw new Exception();
            }
        }
    }

    static public void Menu()
    {
        Console.Write("\nМЕНЮ: \n1-создать героя\n2-создать волшебника\n3-Взять артифакт и положить в сумку\n4-Выкинуть артифакт\n5-Передать артифакт другому игроку\n6-Использовать артифакт\n7-Выучить заклинание\n8-Забыть заклинание\nВвод: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            CreateCharacter();
            break;

            case 2:
            CreateWizard();
            break;

            case 3:
            {
                if(ChoosePlayer() == 1) {
                    GetCaracter().PickUpArtefactAndPutInBag(artifacts.Peek());
                    artifacts.Dequeue();
                }
                else {
                    GetWizard().PickUpArtefactAndPutInBag(artifacts.Peek());
                    artifacts.Dequeue();
                }
                break;
            }

            case 4:
            {
                if(ChoosePlayer() == 1) GetCaracter().ThrowArtefactOutOfBag();
                else GetWizard().ThrowArtefactOutOfBag();
                break;
            }

            case 5:
            {
                Console.Write("герою или волшебнику?(1/2): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if(choose == 1){
                    if(ChoosePlayer() == 1) GetCaracter().TransferArtefactToAnotherCharacter(GetCaracter());
                    else GetWizard().TransferArtefactToAnotherCharacter(GetCaracter());
                }
                else {
                    if(ChoosePlayer() == 1) GetCaracter().TransferArtefactToAnotherCharacter(GetWizard());
                    else GetWizard().TransferArtefactToAnotherCharacter(GetWizard());
                }
                break;
            }

            case 6:
            {
                Console.Write("на герое или волшебнике?(1/2): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if(choose == 1){
                    if(ChoosePlayer() == 1) GetCaracter().UseArtifact(GetCaracter());
                    else GetWizard().UseArtifact(GetCaracter());
                }
                else {
                    if(ChoosePlayer() == 1) GetCaracter().UseArtifact(GetWizard());
                    else GetWizard().UseArtifact(GetWizard());
                }
                break;
            }

            case 7:
            {
                GetWizard().LearnSpell();
                break;
            }
            case 8:
            {
                GetWizard().ForgetSpell();
                break;
            }
            case 9:
            {
                Console.Write("Применить на герое или волшебнике?(1/2): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if(choose == 1){
                    GetWizard().SaySpell(GetWizard(),GetCaracter());
                }
                else {
                    GetWizard().SaySpell(GetWizard(),GetWizard());
                }
                break;
            }

            default:
            {
                Console.WriteLine("Нет такого варианта ответа");
                Menu();
                throw new Exception();
            }
        }
        Menu();
    }
    static public void Main(string[] args)
    {
        characters = new List<Character>();
        wizards = new List<Wizard>();
        artifacts = new Queue<Artifact>();

        artifacts.Enqueue(new LivingWaterButtle(984));
        artifacts.Enqueue(new BasiliskEye(3487, true));
        artifacts.Enqueue(new DeadWaterButtle(545));
        artifacts.Enqueue(new FrogLegsDecoct(3498, true));
        
        artifacts.Enqueue(new PoisonSaliva(3478));
        artifacts.Enqueue(new StaffOfLihtning(234));

        Menu();
    }
}
