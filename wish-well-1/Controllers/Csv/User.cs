﻿using System;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace wish_well_1.Controllers
{
    public class UserLogin
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class CreateUser 
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class User
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string? csv)
        {
            string[] split = csv.Split(",");
            if (split.Length == 4)
            {
                ID = Convert.ToInt32(Uri.UnescapeDataString(split[0].ToString()));
                Name = Uri.UnescapeDataString(split[1].ToString());
                Email = Uri.UnescapeDataString(split[2].ToString());
                Password = Uri.UnescapeDataString(split[3].ToString());
            }
            else
            {
                ID = -1;
                Name = "";
                Email = "";
                Password = "";
            }
        }
        
        public User(int id, string name, string email, string password) {
            ID = id;
            Name = name;
            Email = email;  
            Password = password;
        }

        public string AsCsvSafeString()
        {
            return $"{Uri.EscapeDataString(ID.ToString())},{Uri.EscapeDataString(Name)},{Uri.EscapeDataString(Email)},{Uri.EscapeDataString(Password)}";
        }
    }
}
