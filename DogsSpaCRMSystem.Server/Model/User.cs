﻿namespace DogsSpaCRMSystem.Server.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
    }

}
