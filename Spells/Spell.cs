using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Spell: IMagic
{
    private int minPower;
    private bool verbalComponent;
    private bool motorComponent;
    private bool learned;

    public int MinPower
    {
        get=>minPower;
        set
        {
            if(value < 0) throw new Exception("Мана меньше нуля. ");
            minPower = value;
        }
    }
    
    public bool VerbalComponent { get; set; }
    public bool MotorComponent { get; set; }
    public bool Learned{ get; set;}

    public Spell(int minPower, bool verbalComponent, bool motorComponent)
    {
        MinPower = minPower;
        VerbalComponent = verbalComponent;
        MotorComponent = motorComponent;
    }

    public Spell()
    {
        Learned = false; 
    }

    public void MagicImpact(Character obj)
    {
        if(obj.Health < MinPower) Console.WriteLine("Не хватает маны. ");
        else obj.Health -= MinPower;
    }
    public void MagicImpact(Wizard obj)
    {
        if(obj.Health < MinPower) Console.WriteLine("Не хватает маны. ");
        else obj.Health -= MinPower;
    }

    public void LearnSpell()
    {
        if(!Learned)
        {
            Console.Write("Введите минимальное кол-во силы: ");
            MinPower = Convert.ToInt32(Console.ReadLine());
            Console.Write("Установите истинность утверждения: \"Заклинание нужно говорить\". true/false: ");
            VerbalComponent = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Установите истинность утверждения: \"Для заклинания нужно двигаться\". true/false: ");
            MotorComponent = Convert.ToBoolean(Console.ReadLine());
            Learned = true;
        }
        else Console.WriteLine("Заклинаие уже выучено. ");
    }

    public virtual void Say(Wizard wizard, Wizard obj){}

    public virtual void Say(Wizard wizard, Character obj){}
}