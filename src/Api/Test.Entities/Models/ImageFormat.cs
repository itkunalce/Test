using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.Models;

public class ImageFormat
{
    public int Id { get; set; }
    public string Format { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}
