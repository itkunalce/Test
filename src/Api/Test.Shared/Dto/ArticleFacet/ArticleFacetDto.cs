using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Dto;

public class ArticleFacetDto
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int FacetId { get; set; }
    public FacetDto? Facet { get; set; }
    public string? FacetType { get; set; }
}
