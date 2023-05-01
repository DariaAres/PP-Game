using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

class Wizard : Character
{
    private int mana;
    private int maxMana;
    private ArrayList spells;
    
    public int Mana
    {
        get => mana;
        set
        {
            if(value < 0) throw new Exception("Мана меньше нуля. ");
            mana = value;
        }
    }

    public int MaxMana
    {
        get => maxMana;
        set 
        {
            if(value < 0) throw new Exception("Максимальная мана меньше нуля. ");
            maxMana = value;
        }
    }

    public ArrayList Spells{
        get => spells;
        set 
        {
            if(value == null) throw new Exception("Spells = null. ");
            else spells = value;
        }
    }

    public Wizard(string name, string race, string gender, int maxMana, int mana)
    :base(name, race, gender)
    {
        Mana = mana;
        MaxMana = maxMana;
        Spells = new ArrayList();
    }
    public Wizard():base(){}

    public void SaySpell()
    { 
        Console.Write("Введите заклинание: ");
        string spell = Console.ReadLine();

        Console.Write("Введите его силу: ");
        int power = Convert.ToInt32(Console.ReadLine());

        if(mana - power < 0) Console.WriteLine("Не хватает маны для заклинания. ");
        else Mana -= power;

        Console.WriteLine("\nЗаклинания которые вы знаете: ");
        int i = 0;
        foreach(Object obj in Spells)
        {
            i++;
            Console.WriteLine(i + " = " + obj);
        }

        Console.Write("Какое заклинание хотите использовать?\nВвод(индекс заклинаия): ");
        
    }

    public void AddHealth(Character obj)
    {
        obj.Health = obj.MaxHealth;
    }
    public void AddHealth(Wizard obj)
    {
        obj.Health = obj.MaxHealth;
    }

    public void AddHealth()
    {
        Health = MaxHealth;
    }
    private bool YN(string choose)
    {
        if(choose == "y" || choose == "Y") return true;
        if(choose == "n" || choose == "N") return false;
        else throw new Exception ("Нет такого варианта ответа. ");
    }

    public void Learn()
    {
        Console.Write("Какое заклинание выучить?\n1-добавить здоровье\n2-Противоядие\n3-броня\n4-вылечить\n5-отомри!\n6-оживить\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
            CreateAddHealth();
            break;

            case 2:
            CreateAntidote();
            break;

            case 3:
            CreateArmor();
            break;

            case 4:
            CreateHeal();
            break;

            case 5:
            CreateRevenge();
            break;

            case 6:
            CreateRevive();
            break;
        }

        Console.Write("Использовать заклинание? (y/n): ");
        if(YN(Console.ReadLine())) SaySpell();
    }

    private void CreateAddHealth()
    {
        Console.Write("Какая сила заклинаия?\nВвод: ");
        int power = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Будет присутствовать вербальный компонент? (y/n): ");
        bool verbalComponent = YN(Console.ReadLine());

        Console.WriteLine("Будет моторный вербальный компонент? (y/n): ");
        Spells.Add(new AddHealth(power, verbalComponent, YN(Console.ReadLine())));
    }

    private void CreateAntidote()
    {
        Console.Write("Какая сила заклинаия?\nВвод: ");
        int power = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Будет присутствовать вербальный компонент? (y/n): ");
        bool verbalComponent = YN(Console.ReadLine());

        Console.WriteLine("Будет моторный вербальный компонент? (y/n): ");
        Spells.Add(new Antidote(power, verbalComponent, YN(Console.ReadLine())));
    }

    private void CreateArmor()
    {
        Console.Write("Какая сила заклинаия?\nВвод: ");
        int power = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Будет присутствовать вербальный компонент? (y/n): ");
        bool verbalComponent = YN(Console.ReadLine());

        Console.WriteLine("Будет моторный вербальный компонент? (y/n): ");
        Spells.Add(new Armor(power, verbalComponent, YN(Console.ReadLine())));
    }

    private void CreateHeal()
    {
        Console.Write("Какая сила заклинаия?\nВвод: ");
        int power = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Будет присутствовать вербальный компонент? (y/n): ");
        bool verbalComponent = YN(Console.ReadLine());

        Console.WriteLine("Будет моторный вербальный компонент? (y/n): ");
        Spells.Add(new Heal(power, verbalComponent, YN(Console.ReadLine())));
    }

    private void CreateRevenge()
    {
        Console.Write("Какая сила заклинаия?\nВвод: ");
        int power = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Будет присутствовать вербальный компонент? (y/n): ");
        bool verbalComponent = YN(Console.ReadLine());

        Console.WriteLine("Будет моторный вербальный компонент? (y/n): ");
        Spells.Add(new Revenge(power, verbalComponent, YN(Console.ReadLine())));
    }

    private void CreateRevive()
    {
        Console.Write("Какая сила заклинаия?\nВвод: ");
        int power = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Будет присутствовать вербальный компонент? (y/n): ");
        bool verbalComponent = YN(Console.ReadLine());

        Console.WriteLine("Будет моторный вербальный компонент? (y/n): ");
        Spells.Add(new Revive(power, verbalComponent, YN(Console.ReadLine())));
    }
    public override void LearnSpell()
    {
        base.LearnSpell();
    }

    public override void ForgetSpell()
    {
        base.ForgetSpell();
    }
}