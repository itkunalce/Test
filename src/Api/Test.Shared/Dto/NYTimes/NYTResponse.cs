using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Dto.NYTimes;

public class NYTResponse
{
    public string status { get; set; }
    public string copyright { get; set; }
    public string section { get; set; }
    public DateTime last_updated { get; set; }
    public int num_results { get; set; }
    public List<NYTArticle> results { get; set; }
    public string message { get; set; }
    public bool isSuccess { get; set; }
}
