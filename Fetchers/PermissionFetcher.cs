using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

public class PermissionFetcher
{
    public string Permission { get; set; }
    public string[] Permissions { get; set; }
    private readonly DbConnections _db;
    private readonly IConfiguration _config;

    public PermissionFetcher(DbConnections db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    public void CheckPermission (int userId)
    {
        string [] userinfo =_db.GetUserInfo(userId);
        int permissionid = int.Parse(userinfo[5]);
        string [] permissioninfo = _db.GetPermissions(permissionid);
        Console.WriteLine("Permission is checked");
    }

}