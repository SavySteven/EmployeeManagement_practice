﻿using System.ComponentModel.DataAnnotations;

namespace BasicLibrary.DTOs
{
    public class EmployeeGroup1
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Addresss { get; set; } = string.Empty;

        [Required]
        public string TelephoneNumber { get; set; } = string.Empty;

        [Required]
        public string Photo { get; set; } = string.Empty;

        [Required]
        public string CivilId { get; set; } = string.Empty;

        [Required]
        public string FileNumber { get; set; } = string.Empty;
    }
}
