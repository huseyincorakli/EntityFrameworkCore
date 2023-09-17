using System;
using System.Collections.Generic;

namespace DatabaseFirst.Entities;

public partial class OperationClaim
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
