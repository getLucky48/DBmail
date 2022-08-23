using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.KernelObject
{
    class Inventory : KernelObject
    {

        public string sender { get; set; }
        public Guid package_id { get; set; }
        public int sheet { get; set; }
        public float pay { get; set; }

        public Inventory()
        {

            id = Guid.NewGuid();
            tableName = "inventory";

            package_id = Guid.Empty;
            sheet = 1;
            sender = string.Empty;
            pay = 0.0f;

        }

        public override string prepare_query_select()
        {

            string query = @" select 

                id,
                package_id,
                sender, 
                sheet,
                pay

            ";

            return query;

        }

        public override void Save()
        {

            string query = $@"

                insert into {tableName}(id, package_id, sender, sheet, pay) 
                values ('{id}', '{package_id}', '{sender}', {sheet}, '{pay.ToString().Replace(",", ".")}')

                on conflict (id) do 
                update set 
                    package_id = '{package_id}',
                    sender = '{sender}',
                    sheet = {sheet},
                    pay = {pay.ToString().Replace(",", ".")};

            ";

            DBUtils.execQuery(query);

        }

        protected override void FillByReader(NpgsqlDataReader reader)
        {

            if (reader["id"] != null)
                id = Guid.Parse(reader["id"].ToString());

            if (reader["sender"] != null)
                sender = reader["sender"].ToString();

            if (reader["package_id"] != null)
                package_id = Guid.Parse(reader["package_id"].ToString());

            if (reader["sheet"] != null)
                sheet = int.Parse(reader["sheet"].ToString());

            if (reader["pay"] != null)
                pay = float.Parse(reader["pay"].ToString());

        }
    }
}
