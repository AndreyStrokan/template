using System.Collections.Generic;


public struct Answer
{
    public string Text;
    public Dictionary<Characteristic, int> Characteristics;
    public Dictionary<Characteristic, int> Condition;
    public int NextQuestionIndex;
}
