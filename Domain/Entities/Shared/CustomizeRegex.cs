namespace Domain.Entities.Shared;

public class CustomizeRegex
{
    public const string Mobile = "09([0-9]{9})$";
    public const string Email = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
    public const string MobileNumber = @"^(09)+([1-3]{1})+(\d{8})$";
    public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$";
    public const string Date = @"^[1][3-4][0-9]{2}\/\d{2}\/\d{2}$";
    public const string NationalCode = @"\d{10}";
}