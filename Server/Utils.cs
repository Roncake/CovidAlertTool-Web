using System.Security.Cryptography;
using System.Text;

namespace CovidAlertTool.Server;

public class Utils
{
    public const String LocationsDatabaseConnectionString = "Server=127.0.0.1;Port=3306;Database=covid_alert_tool_locations;Uid=callocations;Pwd=P8WLN5uzPTP75HiSZkpfKPO3ROKAutIU";
    public const String UsersDatabaseConnectionString = "Server=127.0.0.1;Port=3306;Database=covid_alert_tool_users;Uid=calusers;Pwd=keupoGVWGVvLejQaRMTRLdOpvSum1BSI";

    public static String HashWords(IEnumerable<String> words)
    {
        String unhashed = words.Aggregate("", (current, word) => current + word);

        Byte[] bytes = Encoding.UTF8.GetBytes(unhashed);
        Byte[] result;
        using (var sha256 = SHA256.Create())
        {
            result = sha256.ComputeHash(bytes);
        }

        String hexHash = Convert.ToHexString(result);
        return hexHash;
    }
}