using System;
using System.Collections.Generic;

namespace Microservice.Domain.Entities;

public class TbMicroservice
{
    public int? ProposalId { get; set; }

    public int? EmpId { get; set; }

    public int? EventCode { get; set; }

    public string? EmpXml { get; set; }

    public string? DepXml { get; set; }

    public string? Bene1Xml { get; set; }

    public string? Bene2Xml { get; set; }

    public string? Plan1Xml { get; set; }

    public string? CalcVarXml { get; set; }
}
