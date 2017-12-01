﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;
using System.Data.Entity;

namespace Superhero.Data.SightingRepository
{
    public class EFSightingRepo : ISightingRepo
    {
        public void AddSighting(Sighting sighting)
        {
            sighting.Ispublished = true;
            using (var db = new SuperheroDBContext())
            {
                sighting.SightingLocation = db.Locations.FirstOrDefault(l => l.LocationID == sighting.SightingLocation.LocationID);
                foreach (Hero hero in sighting.SightingHeroes )
                {
                    db.Heroes.Attach(hero);
                }
                db.Sightings.Add(sighting);
                db.SaveChanges();
            }
        }

        public void DeleteSighting(int sightingID)
        {
            using (var db = new SuperheroDBContext())
            {
                // might be an issue here with capitalization
                Sighting toRemove = db.Sightings.SingleOrDefault(s => s.SightingID == sightingID);
                if (toRemove != null)
                {
                    db.Sightings.Remove(toRemove);
                }
                db.SaveChanges();
            }            
        }

        //for (int i = toEdit.SightingHeroes.Count - 1; i >= 0; i--)
        //{
        //    toEdit.SightingHeroes.Remove(i);
        //}
        //toEdit.SightingHeroes = sighting.SightingHeroes;
        //db.Heroes.Attach(hero);
        public void EditSighting(Sighting sighting)
        {
            sighting.Ispublished = true;
            using (var db = new SuperheroDBContext())
            {
                Sighting toEdit = db.Sightings.Include("SightingHeroes").SingleOrDefault(s => s.SightingID == sighting.SightingID);
                if (toEdit != null)
                {
                    toEdit.SightingDescription = sighting.SightingDescription;
                    toEdit.Date = sighting.Date;                    
                    toEdit.SightingLocation = sighting.SightingLocation;

                    var heroesToDelete = new List<Hero>();

                    foreach (var hero in toEdit.SightingHeroes)
                    {
                        heroesToDelete.Add(hero);
                    }

                    foreach (var hero in heroesToDelete)
                    {
                        toEdit.SightingHeroes.Remove(hero);
                    }

                    foreach (Hero hero in sighting.SightingHeroes)
                    {
                        db.Heroes.Attach(hero);
                        toEdit.SightingHeroes.Add(hero);                        
                    }                    
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Sighting> GetAllSightings()
        {
            using (var db = new SuperheroDBContext())
            {
                var sightings = from s in db.Sightings
                                select s;
                return sightings.ToList();
            }
        }

        public IEnumerable<Sighting> GetNumberOfSightings(int number, int set)
        {
            using (var db = new SuperheroDBContext())
            {
                var toReturn = db.Sightings.Include("SightingLocation").Include("SightingHeroes").OrderByDescending(s => s.Date).Where(s => s.Ispublished).Skip(number * set).Take(number).ToList();
                return toReturn;
            }
        }

        public IEnumerable<Sighting> GetPendingSightings()
        {
            using (var db = new SuperheroDBContext())
            {
                return db.Sightings.Where(d => d.Ispublished == false).ToList();
            }
        }

        public IEnumerable<Sighting> GetSighintsByDate(string date)
        {
            DateTime day = DateTime.Parse(date);
            using (var db = new SuperheroDBContext())
            {
                return db.Sightings.Where(s => DbFunctions.TruncateTime(s.Date) == day.Date).ToList();
            }
        }

        //This may need to be just id instead of SightingID
        public Sighting GetSightingsById(int SightingID)
        {
            Sighting toReturn = new Sighting();
            using (var db = new SuperheroDBContext())
            {
                var query = from s in db.Sightings.Include("SightingLocation").Include("SightingHeroes")
                            where s.SightingID == SightingID
                            select s;

                foreach (var sighting in query)
                {
                    toReturn = sighting;
                }
            }
            return toReturn;
        }
    }
}