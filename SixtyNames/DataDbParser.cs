using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp1
{
    internal class DataDbParser
    {
        SqlConnectionStringBuilder strCon = new SqlConnectionStringBuilder
            (ConfigurationManager.ConnectionStrings["MSSQLLocalConnectionString"].ConnectionString);
        public int GetSumContracts()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon.ConnectionString))
                {
                    conn.Open();
                    var sqlScript = @"
SELECT
    SUM(ContractSum)
FROM
    Contracts
WHERE 
    Status = N'Подписан'
    AND  YEAR(DateOfSign) = YEAR(GETDATE())
";
                    SqlCommand sqlCmd = new SqlCommand(sqlScript, conn);
                    SqlDataReader r = sqlCmd.ExecuteReader();

                    while (r.Read())
                    {
                       result =  r.GetInt32(0);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return result;
        }

        

        public List<string> GetSumContractsRu()      
        {
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon.ConnectionString))
                {
                    conn.Open();
                    var sqlScript = @"
SELECT 
    CompanyName AS Contractor, SUM(ContractSum) ContracSum
FROM 
    LegalPersons AS l
INNER JOIN Contracts AS c
    ON l.LegalPersonsId = c.LegalPersonsId
    AND l.Country = N'Россия'
GROUP BY CompanyName
";
                    SqlCommand sqlCmd = new SqlCommand(sqlScript, conn);
                    SqlDataReader r = sqlCmd.ExecuteReader();


                    while (r.Read())
                    {
                        result.Add(r.GetString(0));
                        result.Add(r.GetInt32(1).ToString());
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;            
        }

        public List<string> GetEmails()
        {
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon.ConnectionString))
                {
                    conn.Open();
                    var sqlScript = @"
SELECT
    Email 
FROM 
    PhysicalPersons as p
INNER JOIN Contracts as c
    ON p.PhysicalPersonsId = c.PhysicalPersonsId
WHERE
    c.Status = N'Подписан' AND c.ContractSum > 40000 AND c.DateOfSign >= dateadd(day, -30, getdate())
";
                    SqlCommand sqlCmd = new SqlCommand(sqlScript, conn);
                    SqlDataReader r = sqlCmd.ExecuteReader();


                    while (r.Read())
                    {
                        result.Add(r.GetString(0));
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }

        public int StatusChange()
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon.ConnectionString))
                {
                    conn.Open();
                    var sqlScript = @"
UPDATE c
SET c.Status = N'Расторгнут'
FROM
    dbo.Contracts as c
INNER JOIN PhysicalPersons as p 
    ON p.PhysicalPersonsId = c.PhysicalPersonsId
WHERE 
    p.Age > 60 AND c.Status = N'Подписан'
";
                    SqlCommand sqlCmd = new SqlCommand(sqlScript, conn);
                    result = sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }

        public List<string> ExportData()
        {
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon.ConnectionString))
                {
                    conn.Open();
                    var sqlScript = @"
SELECT
    p.Name, p.Surname, p.Patronymic, p.Email, p.Phone, p.Birthday, p.City 
FROM dbo.PhysicalPersons as p 
INNER JOIN dbo.Contracts as c 
    ON c.PhysicalPersonsId = p.PhysicalPersonsId
WHERE
    c.Status = N'Подписан' AND p.City = N'Москва'
";
                    SqlCommand sqlCmd = new SqlCommand(sqlScript, conn);
                    SqlDataReader r = sqlCmd.ExecuteReader();


                    while (r.Read())
                    {
                        result.Add(r.GetString(0));
                        result.Add(r.GetString(1));
                        result.Add(r.GetString(2));
                        result.Add(r.GetString(3));
                        result.Add(r.GetString(4));
                        result.Add(r.GetDateTime(5).ToString("dd.MM.yyyy"));
                        result.Add(r.GetString(6));
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return result;
        }
    }
}
