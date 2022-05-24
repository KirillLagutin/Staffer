using Dapper;
using Microsoft.Data.Sqlite;

namespace Staffer.Lib;

public static class DB
{
    private const string CS = @"Data Source=D:\!Desktop\Step\C#\Projects\ASP\Staffer\staffer.db";

    public static IEnumerable<Staffer> GetAllStaffers()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        using var db = new SqliteConnection(CS);
        
        db.Open();
        
        var sql = @"SELECT tab_persons.id AS 'id', 
       first_name, last_name, date_of_birth,
       department, position
FROM tab_staffers
    JOIN tab_persons 
        ON tab_staffers.person_id = tab_persons.id
    JOIN tab_department
        ON tab_staffers.department_id = tab_department.id
    JOIN tab_positions
        ON tab_staffers.position_id = tab_positions.id;";

        var staffers = db.Query<Staffer>(sql);

        return staffers;
    }
    
}