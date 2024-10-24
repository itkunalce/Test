using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.Models;

public class Multimedia
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Article))]
    public int ArticleId { get; set; }
    public Article? Article { get; set; }
    public string Url { get; set; }
    [ForeignKey(nameof(ImageFormat))]
    public int? ImageFormatId { get; set; }
    public ImageFormat? ImageFormat { get; set; }
    public string? Type { get; set; }
    public string? Subtype { get; set; }
    public string? Caption { get; set; }
    public string? Copyright { get; set; }
}
