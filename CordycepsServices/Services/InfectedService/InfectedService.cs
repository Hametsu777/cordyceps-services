﻿using CordycepsServices.Models;

namespace CordycepsServices.Services.InfectedService
{
    public class InfectedService : IInfectedService
    {
        private static string[] _stages = { "Runner", "Stalker", "Clicker", "Bloater", "Shambler", "RatKing" };

        public List<Infected> InfectedList = new List<Infected>
        {
            new Infected { Stage = _stages[0] },
            new Infected { Stage = _stages[0] },
            new Infected { Stage = _stages[2] },
        };

        public int GetInfectedCount()
        {
            return InfectedList.Count;
        }

        public List<Infected> GetInfectedList()
        {
            return InfectedList;
        }

        public void IncreaseInfected()
        {
            InfectedList.Add(new Infected
            {
                Stage = _stages[new Random().Next(_stages.Length)]
            });
        }
    }
}
