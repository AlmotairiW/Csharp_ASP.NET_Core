using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();

            ViewBag.HockeyLeagues = _context.Leagues
            .Where(l => l.Sport.Contains("Hockey"))
            .ToList();

            ViewBag.NotFootballLeages = _context.Leagues
            .Where(l => l.Sport != "Football")
            .ToList();

            ViewBag.ConferenceLeagues = _context.Leagues
            .Where(l => l.Name.Contains("Conference"))
            .ToList();

            ViewBag.AtlanticLeagues = _context.Leagues
            .Where(l => l.Name.Contains("Atlantic"))
            .ToList();

            ViewBag.DallasTeams = _context.Teams
            .Where( t => t.Location == "Dallas")
            .ToList();
            
            ViewBag.RaptorsTeams = _context.Teams
            .Where( t => t.TeamName == "Raptors")
            .ToList();

            ViewBag.CityTeams = _context.Teams
            .Where(t => t.Location.Contains("City"))
            .ToList();

            ViewBag.Tteams = _context.Teams
            .Where(t => t.TeamName.StartsWith("T"))
            .ToList();

            ViewBag.TeamsOrderedByLoc = _context.Teams
            .OrderBy( t => t.Location)
            .ToList();

            ViewBag.TeamsOrderdByNameRev = _context.Teams
            .OrderByDescending( t => t.TeamName)
            .ToList();

            ViewBag.PlayersWithLnCooper = _context.Players
            .Where(p => p.LastName == "Cooper")
            .ToList();

            ViewBag.PlayersWithFnJoshua = _context.Players
            .Where(p => p.FirstName == "Joshua")
            .ToList();

            ViewBag.CoopersNotJoshuas = _context.Players
            .Where(p => p.LastName == "Cooper" && p.FirstName != "Joshua")
            .ToList();

            ViewBag.AlexandersAndWyatts = _context.Players
            .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt")
            .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {

            ViewBag.ASCTeams = _context.Teams
            .Include(Team => Team.CurrLeague)
            .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference")
            .ToList();

            ViewBag.BPPlayers = _context.Players
            .Include(p => p.CurrentTeam)
            .Where(p => p.CurrentTeam.TeamName == "Penguins")
            .ToList();

            ViewBag.ICBCPlayers = _context.Players
            .Include(p => p.CurrentTeam.CurrLeague)
            .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
            .ToList();

            ViewBag.LopezsInACAF = _context.Players
            .Include(p => p.CurrentTeam.CurrLeague)
            .Where(p => p.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football" && p.LastName == "Lopez")
            .ToList(); //None

            ViewBag.FootballPlayers = _context.Players
            .Include(p => p.CurrentTeam.CurrLeague)
            .Where(p => p.CurrentTeam.CurrLeague.Sport == "Football")
            .ToList();

            ViewBag.SophiasTeams = _context.Players
            .Include( p => p.CurrentTeam)
            .Where(p => p.FirstName == "Sophia")
            .ToList();
            
            // List<Team> allTeams = _context.Teams.Include(t => t.CurrentPlayers).ToList();
            // foreach(Team t in allTeams)
            // {
            //     foreach(Player p in t.CurrentPlayers)
            //     {
            //         if(p.FirstName == "Sophia")
            //         {
            //             Console.WriteLine(t.TeamName);
            //         }
            //     }
            // }

            ViewBag.SophiasLeague = _context.Players
            .Include( p => p.CurrentTeam.CurrLeague)
            .Where(p => p.FirstName == "Sophia")
            .ToList();

            ViewBag.Floress = _context.Players
            .Include(p => p.CurrentTeam)
            .Where(p => p.LastName == "Flores" && p.CurrentTeam.TeamName != "Roughriders")
            .ToList();
            

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            ViewBag.EvansTeams = _context.Players
            .Include(p => p.CurrentTeam)
            .Include(p => p.AllTeams)
            .ThenInclude( tp => tp.TeamOfPlayer)
            .FirstOrDefault(p => p.FirstName == "Samuel" && p.LastName == "Evans");

            ViewBag.AllTigerCatsPlayers = _context.Teams
            .Include(t => t.CurrentPlayers)
            .Include(t => t.AllPlayers)
            .ThenInclude( tp => tp.PlayerOnTeam)
            .FirstOrDefault( t => t.TeamName == "Tiger-Cats" && t.Location == "Manitoba");

            ViewBag.VikingsPlayers = _context.Teams
            .Include( t => t.AllPlayers)
            .ThenInclude( pt => pt.PlayerOnTeam)
            .FirstOrDefault(  t => t.TeamName == "Vikings"  && t.Location == "Wichita");
            
            ViewBag.JacobTeams = _context.Players
            .Include( p => p.AllTeams)
            .ThenInclude( pt => pt.TeamOfPlayer)
            .FirstOrDefault(p => p.FirstName == "Jacob" && p.LastName == "Gray");

            ViewBag.JoshuaAFABP = _context.Players
            .Include( p => p.CurrentTeam)
            .Include( p => p.AllTeams)
            .ThenInclude( pt => pt.TeamOfPlayer)
            .ThenInclude( t => t.CurrLeague)
            .Where(p => p.FirstName == "Joshua").ToList();
            // foreach(Player p in ViewBag.JoshuaAFABP)
            // {
            //     foreach( PlayerTeam pt in p.AllTeams)
            //     {
            //         if(pt.TeamOfPlayer.CurrLeague.Name == "Atlantic Federation of Amateur Baseball Players")
            //         Console.WriteLine(pt.TeamOfPlayer.TeamName + " " + pt.TeamOfPlayer.CurrLeague.Name);
            //     }

            // }

            ViewBag._12MorePlayers = _context.Teams
            .Include( t => t.CurrentPlayers)
            .Include(t => t.AllPlayers)
            // .ThenInclude(pt => pt.PlayerOnTeam)
            .Where(t => (t.AllPlayers.Count + t.CurrentPlayers.Count) >= 12);

            // foreach( Team t in ViewBag._12MorePlayers)
            // {
            //     Console.WriteLine(t.TeamName + " " +(t.AllPlayers.Count + t.CurrentPlayers.Count));
            // }

            ViewBag.AllPlayersSorted = _context.Players
            // .Include( p => p.CurrentTeam)
            .Include(p => p.AllTeams) 
            .OrderByDescending( p => p.AllTeams.Count)
            .ToList();
            // foreach(Player p in ViewBag.AllPlayersSorted)
            // {
            //     Console.WriteLine(p.FirstName + " " + p.AllTeams.Count);
            // }

            return View();
        }

    }
}