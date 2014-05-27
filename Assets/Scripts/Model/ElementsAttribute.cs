
[System.Serializable]
public class ElementAtrribute
{
    public int id;
    public string attributeJsonStr;
}



/// <summary>
/// 0: left    1: right    2: up    3: down
/// </summary>
[System.Serializable]
public class JumpDoorAttribute
{
    public JumpDoorAttribute()
    {
    }
    public int dir;
}
