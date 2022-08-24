using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.KernelObject
{
    public class Employee : KernelObject
    {

        public string surname { get; set; }
        public string phone_number { get; set; }

        public Employee()
        {

            id = Guid.NewGuid();
            tableName = "employee";

            surname = string.Empty;
            phone_number = string.Empty;

        }

        public override string prepare_query_select()
        {

            string query = @" select 
                
                id,
                surname, 
                phone_number

            ";

            return query;

        }

        public override void Save()
        {

            string query = $@"

                insert into {tableName}(id, surname, phone_number) values ('{id}', '{surname}', '{phone_number}')

                on conflict (id) do 
                update set surname = '{surname}', phone_number = '{phone_number}';

            ";

            DBUtils.execQuery(query);

        }

        protected override void FillByReader(NpgsqlDataReader reader)
        {

            if (reader["id"] != null)
                id = Guid.Parse(reader["id"].ToString());

            if (reader["surname"] != null)
                surname = reader["surname"].ToString();

            if (reader["phone_number"] != null)
                phone_number = reader["phone_number"].ToString();

        }

    }

}
