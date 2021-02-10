namespace ZoroDex.SimpleCard.Data.Card
{
    public class UiChangeCardType : UiChangeCardText
    {
        protected override string GetText() => Handler.StaticData.CardType.ToString();
    }
}