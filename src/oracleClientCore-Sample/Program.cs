using System;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace SimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Test dotNetCore.Data.OracleClient with native OCI client");
            Console.WriteLine("2. Test Oracle.ManagedDataAccess.Client");
            Console.WriteLine("Other - exit");
            var key = Console.ReadKey().KeyChar;
            if (key == '1')
            {
                Console.WriteLine("Test dotNetCore.Data.OracleClient with Oci client.");

                Console.WriteLine("create OracleConnection object...");
                //https://stackoverflow.com/questions/9218847/how-do-i-handle-database-connections-with-dapper-in-net
                using (System.Data.Common.DbConnection connection = new System.Data.OracleClient.OracleConnection("Data Source = RHEL5; User ID = TEST; Password = Passw0rd1 "))
                {
                    Console.WriteLine("Open connection...");
                    connection.Open();

                    Console.WriteLine("Create command...");
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT table_name, tablespace_name, num_rows FROM user_tables  WHERE tablespace_name is not null  and num_rows > 0  order by num_rows desc";

                        Console.WriteLine("Execute reader...");
                        using (var reader = command.ExecuteReader())
                        {
                            Console.WriteLine("*** User tables (sample): ***");

                            while (reader.Read())
                            {
                                string tableName = reader.GetString(reader.GetOrdinal("TABLE_NAME"));
                                string tablespace_name = reader.GetString(reader.GetOrdinal("TABLESPACE_NAME"));
                                int rows = reader.GetInt32(reader.GetOrdinal("NUM_ROWS"));
                                Console.WriteLine(tableName + " in tablespace " + tablespace_name + " has " + rows.ToString() + " rows.");
                            };
                        }
                        Console.WriteLine("End reader...");
                        Console.WriteLine();

                        Console.WriteLine("*** Test NLS_LANG settings ***");
                        command.CommandText = "select 'some text in English language' as a, '储物组合带门/抽屉, 白色 卡维肯, 因维肯 白蜡木贴面' as b,  'ľščťžýáííéô§úä' as c from dual";
                        var reader1 = command.ExecuteReader();
                        reader1.Read();
                        string sEnglish = reader1.GetString(0);
                        string sChinese = reader1.GetString(1);
                        string sSlovak = reader1.GetString(2);

                        Console.WriteLine("English from db: " + sEnglish);
                        Console.WriteLine("Chinese from db: " + sChinese);
                        Console.WriteLine("Slovak  from db: " + sSlovak);
                        Console.WriteLine("Chinese from the code: 储物组合带门 / 抽屉, 白色 卡维肯, 因维肯 白蜡木贴面");
                        Console.WriteLine("Slovak  from the code: ľščťžýáííéô§úä");
                    }
                }
                Console.WriteLine("Done Oci Client");
                Console.WriteLine("Press key to exit");
                key = Console.ReadKey().KeyChar;
            }
            else if (key == '2')
            {
                Console.WriteLine("Test Oracle.ManagedDataAccess.Client.");
                Console.WriteLine("create OracleConnection object...");
                //1. Full TNS string in connect string 
                using (System.Data.Common.DbConnection connection = new OracleConnection("Data Source = (DESCRIPTION =  (ADDRESS_LIST =  (ADDRESS = (PROTOCOL = TCP)(HOST = 10.100.103.67)(PORT = 1521)) )(CONNECT_DATA = (SID = ORCL))); User ID = TEST; Password = Passw0rd1 "))
                //2 Withouth TNS , with service name  =  " select value from v$parameter where name='service_names' "
                // using (System.Data.Common.DbConnection connection = new OracleConnection("Data Source =  10.100.103.67:1521/orcl.test.sk; User ID = TEST; Password = Passw0rd1 "))
                // With alias from TNS  
                // using (OracleConnection connection = new OracleConnection(" User ID = TEST; Password = Passw0rd1; Data Source = RHEL5;"))
                {

                    Console.WriteLine("Open connection...");
                    connection.Open();

                    Console.WriteLine("Create command...");
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT table_name, tablespace_name, num_rows FROM user_tables  WHERE tablespace_name is not null  and num_rows > 0  order by num_rows desc";

                        Console.WriteLine("Execute reader...");
                        using (var reader = command.ExecuteReader())
                        {
                            Console.WriteLine("*** User tables (sample): ***");

                            while (reader.Read())
                            {
                                string tableName = reader.GetString(reader.GetOrdinal("TABLE_NAME"));
                                string tablespace_name = reader.GetString(reader.GetOrdinal("TABLESPACE_NAME"));
                                int rows = reader.GetInt32(reader.GetOrdinal("NUM_ROWS"));
                                Console.WriteLine(tableName + " in tablespace " + tablespace_name + " has " + rows.ToString() + " rows.");
                            };
                        }
                        Console.WriteLine("End reader...");
                        Console.WriteLine();

                        Console.WriteLine("*** Test NLS_LANG settings ***");
                        command.CommandText = "select 'some text in English language' as a, '储物组合带门/抽屉, 白色 卡维肯, 因维肯 白蜡木贴面' as b,  'ľščťžýáííéô§úä' as c from dual";
                        var reader1 = command.ExecuteReader();
                        reader1.Read();
                        string sEnglish = reader1.GetString(0);
                        string sChinese = reader1.GetString(1);
                        string sSlovak = reader1.GetString(2);

                        Console.WriteLine("English from db: " + sEnglish);
                        Console.WriteLine("Chinese from db: " + sChinese);
                        Console.WriteLine("Slovak  from db: " + sSlovak);
                        Console.WriteLine("Chinese from the code: 储物组合带门 / 抽屉, 白色 卡维肯, 因维肯 白蜡木贴面");
                        Console.WriteLine("Slovak  from the code: ľščťžýáííéô§úä");
                    }
                }
                Console.WriteLine("Done Oracle.ManagedDataAccess.Client");
                Console.WriteLine("Press key to exit");
                key = Console.ReadKey().KeyChar;
            }
            
        }
    }
}
