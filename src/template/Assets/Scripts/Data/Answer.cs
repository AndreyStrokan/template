using System.Collections.Generic;


public struct AnswerDTO
{
    public string Text;
    public Dictionary<int, int> ImpactOnCharacteristics;
    public Dictionary<int, ConditionDTO> AvailabilityCondition;
}

public enum ConditionType
{
    MoreThan,
    LessThan
}

public struct ConditionDTO
{
    public ConditionType Type { get; set; }
    public int Value { get; set; }
}