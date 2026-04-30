namespace UserService.Infrastructure.Configurations;

public class KafkaSettings
{
    public string BootstrapServers { get; set; } = string.Empty;
    public Dictionary<string, string> Topics { get; set; } = new();
}