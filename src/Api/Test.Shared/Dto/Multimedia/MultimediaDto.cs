using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Dto;

public class MultimediaDto
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public string Url { get; set; }
    public int? ImageFormatId { get; set; }
    public ImageFormatDto? ImageFormat { get; set; }
    public string? Type { get; set; }
    public string? Subtype { get; set; }
    public string? Caption { get; set; }
    public string? Copyright { get; set; }
}
