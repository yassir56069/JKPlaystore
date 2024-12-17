namespace JKPlaystore.Models
{
    public class CustomerDeviceDto
    {
        public int DeviceID { get; set; }
        public string? DeviceCode { get; set; }
        public string? DeviceModel { get; set; }
        public string? CustomerKey { get; set; }
        public DateTime TokenInitDate { get; set; }
        public string? TokenValue { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }

}
