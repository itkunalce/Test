using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Exceptions.Common;

namespace Test.Entities.Exceptions;

public sealed class GeneralNotFoundException : NotFoundException
{
    public GeneralNotFoundException(int companyId, string EntityName) : 
        base($"The {EntityName} with id: {companyId} doesn't exist in the database.")
    {
    }
}
