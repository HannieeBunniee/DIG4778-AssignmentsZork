﻿using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Zork.common;

namespace Zork
{
    public class Player
    {
        public World World { get; }
        public int Moves { get; set; }

        public int Score { get; set; }

        [JsonIgnore]
        public Room Location { get; private set; }

        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }
            return isValidMove;
        }
    }
}
