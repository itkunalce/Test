using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.Models;

public class ArticleFacet
{
    public int Id { get; set; }
    [ForeignKey(nameof(Article))]
    public int ArticleId { get; set; }
    [ForeignKey(nameof(FacetId))]
    public int FacetId { get; set; }
    public Facet? Facet { get; set; }
    public string? FacetType { get; set; }
}
