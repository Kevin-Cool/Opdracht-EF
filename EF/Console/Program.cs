using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using ClassLibrary;
using ClassLibrary.Data;
using ClassLibrary.Data.Repositories;
using ClassLibrary.Model.IRepositories;

namespace ConsoleApp
{
    class Program
    {
        public EFoefContext _ctx = new EFoefContext();
        static void Main(string[] args)
        {
            string path = @"..\..\..\..\databank\foot.csv";
            //InitialiseerDatabank(path);
            testCode();
        }
        static public void testCode()
        {
            using (EFoefContext ctx = new EFoefContext())
            {
                TeamRepository teamRepo = new TeamRepository(ctx);
                SpelerRepository spelerRepo = new SpelerRepository(ctx);
                TransferRepository TransferRepo = new TransferRepository(ctx);

                // Voeg Nieuwe Speler toe
                Speler speler = new Speler("Nicolas", 13, 1000, teamRepo.SelecteerTeam(3));
                spelerRepo.VoegSpelerToe(speler);

                // Voeg Nieuwe Team toe
                Team team = new Team(69, "team naam", "bijnaam", "trainer");
                teamRepo.VoegTeamToe(team);

                // voeg Nieuwe transfertoe
                Transfer transfer = new Transfer(spelerRepo.SelecteerSpeler(5), 55555.55, teamRepo.SelecteerTeam(35), teamRepo.SelecteerTeam(3));
                TransferRepo.VoegTransferToe(transfer);

                // update speler
                Speler spelerUpdate = spelerRepo.SelecteerSpeler(4);
                spelerUpdate.Naam = "Nieuwe naam";
                spelerRepo.UpdateSpeler(spelerUpdate);

                // update team
                Team teamUpdate = teamRepo.SelecteerTeam(35);
                teamUpdate.Naam = "Nieuwe naam";
                teamRepo.UpdateTeam(teamUpdate);

                ctx.SaveChanges();
            }
        }
        static public void InitialiseerDatabank(string path)
        {
            Dictionary<string, Team> teamrDict = new Dictionary<string, Team>();
            HashSet<Speler> spelerSet = new HashSet<Speler>();
            using (StreamReader r = new StreamReader(path))
            {
                string line;        string naam;
                int nummer;         string team;
                int waarde;      int stamnr;
                string trainer;     string bijnaam;
                while ((line = r.ReadLine())!=null)
                {
                    if(!(line == "naam,nummer,club,waarde,stamnr,trainer,bijnaam"))
                    {
                        string[] ss = line.Split(",").Select(x => x.Trim()).ToArray();
                        naam = ss[0];
                        nummer = int.Parse(ss[1]);
                        team = ss[2];
                        waarde = int.Parse(ss[3].Replace(" ", ""));
                        stamnr = int.Parse(ss[4]);
                        trainer = ss[5];
                        bijnaam = ss[6];
                        if (!teamrDict.ContainsKey(team)) teamrDict.Add(team, new Team(stamnr, team, bijnaam, trainer));
                        spelerSet.Add(new Speler(naam, nummer, (double)waarde, teamrDict[team]));
                    }
                    
                }
            }
            using (EFoefContext ctx = new EFoefContext())
            {
                TeamRepository teamRepo = new TeamRepository(ctx);
                SpelerRepository spelerRepo = new SpelerRepository(ctx);
                TransferRepository TransferRepo = new TransferRepository(ctx);
                foreach (Team item in teamrDict.Values)
                {
                    teamRepo.VoegTeamToe(item);
                }

                foreach (Speler item in spelerSet)
                {
                    spelerRepo.VoegSpelerToe(item);
                }
                ctx.SaveChanges();
            }
            Console.WriteLine("Einde");
        }
    }
}
