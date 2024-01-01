using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Requests
{
    public class UlogePostRequest
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string NazivUloge { get; set; } = null!;

        public string? OpisUloge { get; set; }
    }
}
