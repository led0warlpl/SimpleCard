namespace ZoroDex.SimpleCard.Data.Card
{
    public class UiChangeCardDescription : UiChangeCardText
    {
        protected override string GetText() => Handler.StaticData.Description;
    }
}