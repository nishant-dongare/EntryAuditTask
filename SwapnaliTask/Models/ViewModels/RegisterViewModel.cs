﻿using System.ComponentModel.DataAnnotations;

namespace SwapnaliTask.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password{ get; set; }
    }
}
