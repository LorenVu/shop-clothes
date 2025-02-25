namespace BuildingBlock.Shared.Configs;

public class BackgroundJobSettings
{
    public string? HangfireUrl { get; private set; }
    public string? CheckoutUrl { get; private set; }
    public string? BasketUrl { get; private set; }
    public string? ScheduleJobUrl { get; private set; }
}