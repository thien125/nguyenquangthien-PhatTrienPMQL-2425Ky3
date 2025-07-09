namespace DemoMVC.Models
{
    public static class Auto
    {
        public static string GenerateNewId(string? lastId)
        {
            if (string.IsNullOrEmpty(lastId))
            {
                return "PS00001";
            }

            // Lấy phần số sau "PS"
            var numberPart = lastId.Substring(2);

            if (int.TryParse(numberPart, out int lastNumber))
            {
                return "PS" + (lastNumber + 1).ToString("D5");
            }

            // Nếu không parse được thì trả về mặc định
            return "PS00001";
        }
    }
}