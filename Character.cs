using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Character : IComparable<Character>
{
    private long id; //
    private string name; //
    private string state;
    private bool speakAbility;
    private bool moveAbility;
    private string race; //
    private string gender; //
    private int age;
    private int health;
    private int maxHealth;
    private int experience;
    private Inventory invent;

    private AddHealth addHealth = new AddHealth();
    private Antidote antidote = new Antidote();
    private Armor armor = new Armor();
    private Heal heal = new Heal();
    private Revenge revenge = new Revenge();
    private Revive revive = new Revive();
    public long Id
    {
        get => id;
        set
        {
            if(value < 0) throw new Exception("Id меньше нуля. ");
            id = value;
        }
    }
    public string Name
    {
        get => name;
        set
        {
            if(Char.IsLower(value[0])) throw new Exception(" Имя с маленькой буквы. ");
            name = value;
        }
    }
    public string State
    {
        get => state;
        set 
        {
            if(value == "здоров" || value == "ослаблен" || value == "болен" || value == "отравлен" || value == "парализован" || value == "мертв") 
                state = value;
            else 
                throw new Exception("Вы уверены во введенном состоянии? ");
        }
    }
    public bool SpeakAbility { get; set; }

    public bool MoveAbility { get; set; }
    public string Race 
    {
        get => race;
        set
        {
            if(value == "человек" || value == "гном" || value == "эльф" || value == "гном" || value == "гоблин") 
                race = value;
            else 
                throw new Exception("Вы уверены во введенной расе? ");
        }
    }

    public string Gender
    {
        get => gender;
        set
        {
            if(value == "м" || value == "д")
                gender = value;
            else 
                throw new Exception("Вы уверены во введенном поле? ");
        }
    }

    public int Age
    {
        get => age;
        set 
        {
            if (value < 0) throw new Exception("Возраст меньше нуля. ");
            age = value;
        }
    }
    public int Health
    {
        get => health;
        set
        {
            if(value < 0)throw new Exception("Здоровье меньше нуля. ");
            health = value;
        }
    }
    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            if(value < 0)throw new Exception("Максимально здоровье меньше нуля. ");
            maxHealth = value;
        }
    }
    public int Experience
    {
        get => experience;
        set
        {
            if(value < 0)throw new Exception("Максимально здоровье меньше нуля. ");
            experience = value;
        }
    }

    public Inventory Invent{
        get => invent;
        set {
            if(value == null) throw new Exception("Инвентарь не создан. ");
            else invent = value;
        }
    }

    public Character(string name, string race, string gender)
    {
        Id = GenerateID();
        Name = name;
        Race = race;
        Gender = gender;
        State = "здоров";
        SpeakAbility = true;
        MoveAbility = true;
        Age = 0;
        MaxHealth = 10;
        Health = 0;
        Experience = 0;
        Invent = new Inventory();
    }
    public Character(){}

    public int CompareTo(Character obj)
    {
        if (obj is null) throw new Exception("Некорректное значение параметра");
        return Math.Sign(Experience - obj.Experience);
    }

    private long GenerateID()
    {
        return DateTime.Now.Ticks - new DateTime(2021, 4, 29).Ticks;
    }
    private double HelthPorcents()
    {
        return Health * 100 / (double)MaxHealth;
    }
    public void UpdateState()
    {
        if( HelthPorcents() < 10) State = "ослаблен";
        else if( HelthPorcents() >= 10) State = "здоров";
        else if( HelthPorcents() == 0) State = "мертв";
    }

    public override string ToString()
    {
        return "ID: " + Id + "\nИмя: " + Name + "\nРаса: " + Race + "\nПол: " + Gender + "\nСостояние: " + State + "\nВозможность говорить: " + SpeakAbility + "\nВозможность двигаться: " + MoveAbility + "\nВозраст: " + Age + "\nМаксимальное здоровье: " + MaxHealth + "\nЗдоровье: " + Health + "\nОпыт: " + Experience; 
    }

    public void PickUpArtefactAndPutInBag(Artifact obj)
    {
        invent.Adding(obj);
    }

    public void ThrowArtefactOutOfBag()
    {
        invent.Removing(invent.TakeArtifact());
    }


    public void TransferArtefactToAnotherCharacter(Character pers)
    {
        Artifact obj = invent.TakeArtifact();
        pers.invent.Adding(obj);
        invent.Removing(obj);
    }
   

    public void UseArtifact(Wizard obj)
    {
        Console.Write("Какой артефакт хотите использовать?\n1-Глаз василиска\n2-Бутылка с мертвой водой\n3-Декокт из лягушачьих лапок\n4-ядовитая слюнаn\n5-Посох\"Молния\"\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            invent.UseBasiliskEye(obj);
            break;

            case 2:
            invent.UseDeadWaterButtle(obj);
            break;

            case 3:
            invent.UseFrogLegsDecoct(obj);
            break;

            case 4:
            invent.UsePoisonSaliva(obj);
            break;

            case 5:
            invent.UseStaffOfLihtning(obj);
            break;

            default:
            throw new Exception("Нет такого варианта ответа! ");
        }
    }

    public void UseArtifact(Character obj)
    {
        Console.Write("Какой артефакт хотите использовать?\n1-Глаз василиска\n2-Декокт из лягушачьих лапок\n3-Бутылка с живой водой\n4-ядовитая слюнаn\n5-Посох\"Молния\"\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            invent.UseBasiliskEye(obj);
            break;

            case 2:
            invent.UseFrogLegsDecoct(obj);
            break;

            case 3:
            invent.UseLivingWaterButtle(obj);
            break;

            case 4:
            invent.UsePoisonSaliva(obj);
            break;

            case 5:
            invent.UseStaffOfLihtning(obj);
            break;

            default:
            throw new Exception("Нет такого варианта ответа! ");
        }
    }
   
    public virtual void LearnSpell()
    {
        Console.Write("Какое заклинание хотите выучить?\n1-Добавить здоровье\n2-Противоядие\n3-Броня\n4-Вылечить\n5-Отомри!\n6-Оживить\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            addHealth.LearnSpell();
            break;
            
            case 2:
            antidote.LearnSpell();
            break;

            case 3:
            armor.LearnSpell();
            break;

            case 4:
            heal.LearnSpell();
            break;

            case 5:
            revenge.LearnSpell();
            break;

            case 6:
            revive.LearnSpell();
            break;

            default:
            throw new Exception("Нет такого варианта ответа! ");
        }
    }
   
    public virtual void ForgetSpell()
    {
        Console.Write("Какое заклинание хотите забыть?\n1-Добавить здоровье\n2-Противоядие\n3-Броня\n4-Вылечить\n5-Отомри!\n6-Оживить\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            addHealth.Learned = false;
            break;
            
            case 2:
            antidote.Learned = false;
            break;

            case 3:
            armor.Learned = false;
            break;

            case 4:
            heal.Learned = false;
            break;

            case 5:
            revenge.Learned = false;
            break;

            case 6:
            revive.Learned = false;
            break;

            default:
            throw new Exception("Нет такого варианта ответа! ");
        }
    }
    public void SaySpell(Wizard wizard, Character obj)
    {
        Console.Write("Какое заклинание хотите сказать?\n1-Добавить здоровье\n2-Противоядие\n3-Броня\n4-Вылечить\n5-Отомри!\n6-Оживить\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            addHealth.Say(wizard, obj);
            break;
            
            case 2:
            antidote.Say(wizard, obj);
            break;

            case 3:
            armor.Say(wizard, obj);
            break;

            case 4:
            heal.Say(wizard, obj);
            break;

            case 5:
            revenge.Say(wizard, obj);
            break;

            case 6:
            revive.Say(wizard, obj);
            break;

            default:
            throw new Exception("Нет такого варианта ответа! ");
        }
    }

    public void SaySpell(Wizard wizard, Wizard obj)
    {
        Console.Write("Какое заклинание хотите сказать?\n1-Добавить здоровье\n2-Противоядие\n3-Броня\n4-Вылечить\n5-Отомри!\n6-Оживить\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            addHealth.Say(wizard, obj);
            break;
            
            case 2:
            antidote.Say(wizard, obj);
            break;

            case 3:
            armor.Say(wizard, obj);
            break;

            case 4:
            heal.Say(wizard, obj);
            break;

            case 5:
            revenge.Say(wizard, obj);
            break;

            case 6:
            revive.Say(wizard, obj);
            break;

            default:
            throw new Exception("Нет такого варианта ответа! ");
        }
    }
    
}