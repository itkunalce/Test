using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Dto;

public class ArticleDto
{
    public int Id { get; set; }
    [ForeignKey(nameof(Section))]
    public int? SectionId { get; set; }
    public SectionDto? Section { get; set; }
    [ForeignKey(nameof(Subsection))]
    public int? SubsectionId { get; set; }
    public SubsectionDto? Subsection { get; set; }
    public string? Title { get; set; }
    public string? Abstract { get; set; }
    public string? Url { get; set; }
    public string? Uri { get; set; }
    public string? Byline { get; set; }
    public string? ItemType { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? PublishedDate { get; set; }
    public string? MaterialTypeFacet { get; set; }
    public string? Kicker { get; set; }
    public List<ArticleFacetDto>? ArticleFacet { get; set; } // Des, Org, Per, Geo
    public List<MultimediaDto>? Multimedia { get; set; }
    public string? ShortUrl { get; set; }
}
