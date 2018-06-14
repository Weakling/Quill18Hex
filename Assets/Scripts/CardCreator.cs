using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : Card {

    public Card cardPrefab;
    public Transform contentNecro, contentTera, contentPhaze, contentNeutral;



	void Start ()
    {
        // necro
        CreateCard("Mimring", EnRace.Dragon, EnType.UniqueHero, EnClass.Beast, EnSize.Huge, EnTrait.Ferocious, EnFaction.Necro, 9, 150, 5, 6, 1, 4, 3);
        CreateCard("Grimnak", EnRace.Orc, EnType.UniqueHero, EnClass.Champion, EnSize.Huge, EnTrait.Ferocious, EnFaction.Necro, 11, 120, 5, 5, 1, 2, 4);
        CreateCard("Brunak", EnRace.Trolticor, EnType.UniqueHero, EnClass.Mount, EnSize.Huge, EnTrait.Ferocious, EnFaction.Necro, 8, 110, 3, 6, 1, 4, 7);
        CreateCard("Othkurik", EnRace.Dragon, EnType.UniqueHero, EnClass.Young, EnSize.Large, EnTrait.Tricky, EnFaction.Necro, 6, 140, 5, 6, 1, 4, 2);
        CreateCard("Deepwyrm Drow", EnRace.Drow, EnType.Squad, EnClass.Warrior, EnSize.Medium, EnTrait.Tricky, EnFaction.Necro, 5, 70, 1, 6, 1, 3, 3);
        CreateCard("Pelloth", EnRace.Drow, EnType.UniqueHero, EnClass.Arachnomancer, EnSize.Medium, EnTrait.Devout, EnFaction.Necro, 5, 100, 4, 6, 5, 3, 3);
        CreateCard("Feral Troll", EnRace.Troll, EnType.UniqueHero, EnClass.Hunter, EnSize.Large, EnTrait.Ferocious, EnFaction.Necro, 7, 90, 8, 5, 1, 3, 1);
        CreateCard("Marrden Nagrubs", EnRace.Nargrub, EnType.Squad, EnClass.Guard, EnSize.Small, EnTrait.Loyal, EnFaction.Necro, 3, 30, 1, 6, 1, 2, 2);
        CreateCard("Marro Stingers", EnRace.Marro, EnType.Squad, EnClass.Stinger, EnSize.Medium, EnTrait.Wild, EnFaction.Necro, 4, 60, 1, 5, 5, 3, 3);
        CreateCard("Marro Drudge", EnRace.Marro, EnType.Squad, EnClass.Hunter, EnSize.Medium, EnTrait.Wild, EnFaction.Necro, 4, 50, 1, 5, 5, 2, 2);
        CreateCard("Marro Warriors", EnRace.Marro, EnType.UniqueSquad, EnClass.Warrior, EnSize.Medium, EnTrait.Wild, EnFaction.Necro, 4, 50, 1, 6, 6, 2, 3);
        CreateCard("Ne-Gok-Sa", EnRace.Marro, EnType.UniqueHero, EnClass.Warlord, EnSize.Medium, EnTrait.Tricky, EnFaction.Necro, 5, 90, 5, 5, 1, 3, 6);
        CreateCard("Tor-Kul-Na", EnRace.Marro, EnType.UniqueHero, EnClass.Hivelord, EnSize.Huge, EnTrait.Terrifying, EnFaction.Necro, 11, 220, 6, 6, 1, 6, 5);
        CreateCard("Marro Hive", EnRace.Marro, EnType.UniqueHero, EnClass.Hive, EnSize.Huge, EnTrait.Terrifying, EnFaction.Necro, 17, 160, 6, 0, 1, 1, 2);
        CreateCard("Su-Bak-Na", EnRace.Marro, EnType.UniqueHero, EnClass.Hivelord, EnSize.Huge, EnTrait.Tricky, EnFaction.Necro, 12, 160, 5, 6, 1, 7, 3);
        CreateCard("Zettian Guards", EnRace.Soulborg, EnType.UniqueSquad, EnClass.Guard, EnSize.Medium, EnTrait.Precise, EnFaction.Necro, 5, 70, 1, 4, 7, 2, 7);
        CreateCard("Deathwalker 8000", EnRace.Soulborg, EnType.UniqueHero, EnClass.Deathwalker, EnSize.Large, EnTrait.Precise, EnFaction.Necro, 7, 130, 1, 5, 7, 3, 8);
        CreateCard("Deathwalker 9000", EnRace.Soulborg, EnType.UniqueHero, EnClass.Deathwalker, EnSize.Large, EnTrait.Precise, EnFaction.Necro, 7, 140, 1, 5, 7, 4, 9);
        
        // tera
        CreateCard("Syvarris", EnRace.Elf, EnType.UniqueHero, EnClass.Archer, EnSize.Medium, EnTrait.Precise, EnFaction.Tera, 5, 100, 4, 5, 9, 3, 2);
        CreateCard("Elite Onyx Vipers", EnRace.Viper, EnType.UniqueSquad, EnClass.Scout, EnSize.Medium, EnTrait.Precise, EnFaction.Tera, 5, 100, 1, 7, 1, 3, 2);
        CreateCard("Sonlen", EnRace.Elf, EnType.UniqueHero, EnClass.Archmage, EnSize.Medium, EnTrait.Tricky, EnFaction.Tera, 5, 160, 6, 5, 6, 4, 3);
        CreateCard("Charos", EnRace.Dragon, EnType.UniqueHero, EnClass.King, EnSize.Huge, EnTrait.Valiant, EnFaction.Tera, 9, 210, 9, 5, 1, 5, 5);

        // phase
        CreateCard("Major Q10", EnRace.Soulborg, EnType.UniqueHero, EnClass.Major, EnSize.Large, EnTrait.Merciful, EnFaction.Neutral, 6, 150, 4, 5, 9, 4, 5);
        CreateCard("Krav Maga Agents", EnRace.Human, EnType.UniqueSquad, EnClass.Agent, EnSize.Medium, EnTrait.Tricky, EnFaction.Phaze, 4, 100, 1, 6, 7, 3, 3);
        CreateCard("Agent Carr", EnRace.Human, EnType.UniqueHero, EnClass.Agent, EnSize.Medium, EnTrait.Tricky, EnFaction.Phaze, 5, 100, 4, 5, 6, 2, 4);
        CreateCard("Dund", EnRace.Doggin, EnType.UniqueHero, EnClass.Hunter, EnSize.Large, EnTrait.Tricky, EnFaction.Phaze, 4, 110, 4, 6, 1, 3, 5);

        // neutral
        CreateCard("Raelin", EnRace.Kyrie, EnType.UniqueHero, EnClass.Warrior, EnSize.Medium, EnTrait.Merciful, EnFaction.Phaze, 5, 80, 5, 6, 1, 3, 3);
        CreateCard("Raelin Elite", EnRace.Kyrie, EnType.UniqueHero, EnClass.Warlord, EnSize.Medium, EnTrait.Resolute, EnFaction.Phaze, 5, 120, 5, 6, 1, 3, 3);
        CreateCard("Airborne Elite", EnRace.Human, EnType.UniqueSquad, EnClass.Soldier, EnSize.Medium, EnTrait.Disciplined, EnFaction.Phaze, 5, 110, 1, 4, 8, 3, 2);
        CreateCard("Sgt. Drake Alexander", EnRace.Human, EnType.UniqueHero, EnClass.Soldier, EnSize.Medium, EnTrait.Valiant, EnFaction.Phaze, 5, 110, 5, 5, 1, 6, 3);
        CreateCard("Sgt. Drake Alexander", EnRace.Human, EnType.UniqueHero, EnClass.Soldier, EnSize.Medium, EnTrait.Valiant, EnFaction.Phaze, 5, 170, 6, 6, 1, 6, 4);
        CreateCard("Tarn Viking Warriors", EnRace.Human, EnType.UniqueSquad, EnClass.Warrior, EnSize.Medium, EnTrait.Wild, EnFaction.Phaze, 5, 50, 1, 4, 1, 3, 4);
        CreateCard("Finn the Viking Champion", EnRace.Human, EnType.UniqueHero, EnClass.Champion, EnSize.Medium, EnTrait.Valiant, EnFaction.Phaze, 5, 80, 4, 5, 1, 3, 4);
        CreateCard("Thorgrim the Viking Champion", EnRace.Human, EnType.UniqueHero, EnClass.Champion, EnSize.Medium, EnTrait.Valiant, EnFaction.Phaze, 5, 80, 4, 5, 1, 3, 4);
        CreateCard("Erevan Sunshadow", EnRace.Eladrin, EnType.UniqueHero, EnClass.Wizard, EnSize.Medium, EnTrait.Precise, EnFaction.Phaze, 5, 80, 5, 6, 1, 2, 2);
    }
	



    void CreateCard(string Name, EnRace Race, EnType Type, EnClass Class, EnSize Size, EnTrait Trait, EnFaction Faction,
        int Height, int Cost, int Life, int Move, int Range, int Attack, int Defense)
    {
        // create
        Card newCard = Instantiate(cardPrefab);

        newCard.attName = Name;
        newCard.name = Name;

        // set attributes
        newCard.attType = Type;
        newCard.attRace = Race;
        newCard.attClass = Class;
        newCard.attTrait = Trait;
        newCard.attSize = Size;
        newCard.attSizeHeight = Height;
        newCard.attCost = Cost;
        newCard.attFaction = Faction;

        // set stats
        newCard.statMaxLife = Life;
        newCard.statMaxMove = Move;
        newCard.statMaxRange = Range;
        newCard.statMaxAttack = Attack;
        newCard.statMaxDefense = Defense;

        // set parent
        if(newCard.attFaction == EnFaction.Necro)
        {
            newCard.transform.SetParent(contentNecro);
        }
        else if(newCard.attFaction == EnFaction.Tera)
        {
            newCard.transform.SetParent(contentTera);
        }
        else if (newCard.attFaction == EnFaction.Phaze)
        {
            newCard.transform.SetParent(contentPhaze);
        }
        else if (newCard.attFaction == EnFaction.Neutral)
        {
            newCard.transform.SetParent(contentNeutral);
        }
    }
}
