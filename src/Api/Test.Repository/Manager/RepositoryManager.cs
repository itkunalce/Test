using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Contracts.Manager;
using Test.Contracts.Repository;
using Test.Repository.Repository;

namespace Test.Repository.Manager;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly TestDbContext db;

    private readonly Lazy<IArticleRepository> _article;
    private readonly Lazy<ISectionRepository> _section;
    private readonly Lazy<ISubsectionRepository> _subsection;
    private readonly Lazy<IImageFormatRepository > _imageformat;
    private readonly Lazy<IFacetRepository> _facet;



    public RepositoryManager(TestDbContext _db)
    {
        db = _db;
        _article = new Lazy<IArticleRepository>(() => new ArticleRepository(db));
        _section = new Lazy<ISectionRepository>(() => new SectionRepository(db));
        _subsection = new Lazy<ISubsectionRepository>(() => new SubsectionRepository(db));
        _imageformat = new Lazy<IImageFormatRepository>(() => new ImageFormatRepository(db));
        _facet = new Lazy<IFacetRepository>(() => new FacetRepository(db));
    }
    public IArticleRepository Article => _article.Value;
    public ISectionRepository Section => _section.Value;
    public ISubsectionRepository Subsection => _subsection.Value;
    public IImageFormatRepository Imageformat => _imageformat.Value;
    public IFacetRepository Facet => _facet.Value;

    public async Task SaveAsync()
    {
       await db.SaveChangesAsync();
    }
}
