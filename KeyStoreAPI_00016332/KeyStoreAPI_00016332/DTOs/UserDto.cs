﻿namespace KeyStoreAPI_00016332.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
             
    }
}