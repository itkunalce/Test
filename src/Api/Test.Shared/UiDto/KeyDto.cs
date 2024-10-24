using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.UiDto;

public class KeyDto
{
    [Required(ErrorMessage = "Please enter key")]
    public string Key { get; set; }
}
