﻿namespace CenedQualificando.Domain.Models.Base.ValueObjects;

public class OrderByField
{
    public string FieldName { get; set; }
    public OrderByTypeEnum OrderType { get; set; }
}

public enum OrderByTypeEnum
{
    ASC,
    DESC
}
