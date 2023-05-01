using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

class Inventory
{
    private List<Artifact> artifacts;   
    public List<Artifact> Artifacts{
        get => artifacts;
        set {
            if(value == null) throw new Exception("Коллекция NULL");
            else artifacts = value; 
        }
    }    
    public Inventory(){
        Artifacts = new List<Artifact>();
    }

    public void Adding(Artifact obj){
        Artifacts.Add(obj);
    }
    
    public void Removing(Artifact obj){
        Artifacts.Remove(obj);
    }

    public Artifact TakeArtifact()
    {
        int i = 0;
        foreach(Artifact art in artifacts){
            Console.WriteLine(i + " - " + art.ToString());
            i++;
        }
        Console.Write("Введите индекс артифакта: ");
        return artifacts[Convert.ToInt32(Console.ReadLine())];
    }

    public void UseBasiliskEye(Character obj)
    {
        foreach(Artifact a in artifacts){
            if(a.GetType() == new BasiliskEye().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }//
    public void UseBasiliskEye(Wizard obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new BasiliskEye().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }//

    public void UseDeadWaterButtle(Wizard obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new DeadWaterButtle().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }//wizard

    public void UseFrogLegsDecoct(Character obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new FrogLegsDecoct().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }//

    public void UseFrogLegsDecoct(Wizard obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new FrogLegsDecoct().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }//

    public void UseLivingWaterButtle(Character  obj){
        artifacts[0].Use(obj);
    }
    
    public void UsePoisonSaliva(Wizard obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new PoisonSaliva().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }

    public void UsePoisonSaliva(Character obj){
         foreach(Artifact a in artifacts){
            if(a.GetType() == new PoisonSaliva().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }

    public void UseStaffOfLihtning(Character obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new StaffOfLihtning().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }
    public void UseStaffOfLihtning(Wizard obj){
        foreach(Artifact a in artifacts){
            if(a.GetType() == new StaffOfLihtning().GetType()){
                a.Use(obj);
                if(a.Renewability == false) artifacts.Remove(a);
            } 
        }
    }

}