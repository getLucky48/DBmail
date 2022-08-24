using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.KernelObject
{
    class InventoryContainer : KernelObject
    {

        public string name { get; set; }
        public Guid inventory_id { get; set; }
        public int count { get; set; }
        public float pay { get; set; }

        public InventoryContainer()
        {

            id = Guid.NewGuid();
            tableName = "inventory_container";

            inventory_id = Guid.Empty;
            name = string.Empty;
            count = 0;
            pay = 0.0f;

        }

        public override string prepare_query_select()
        {

            string query = @" select 

                id,
                inventory_id,
                name, 
                count,
                pay

            ";

            return query;

        }

        public override void Save()
        {

            string query = $@"

                insert into {tableName}(id, name, count, pay, inventory_id) 
                values ('{id}', '{name}', {count}, {pay.ToString().Replace(",", ".")}, '{inventory_id}')

                on conflict (id) do 
                update set name = '{name}', count = {count}, pay = {pay.ToString().Replace(",", ".")}, inventory_id = '{inventory_id}';

            ";

            DBUtils.execQuery(query);

        }

        protected override void FillByReader(NpgsqlDataReader reader)
        {

            if (reader["id"] != null)
                id = Guid.Parse(reader["id"].ToString());

            if (reader["name"] != null)
                name = reader["name"].ToString();

            if (reader["inventory_id"] != null)
                inventory_id = Guid.Parse(reader["inventory_id"].ToString());

            if (reader["count"] != null)
                count = int.Parse(reader["count"].ToString());

            if (reader["pay"] != null)
                pay = float.Parse(reader["pay"].ToString());

        }
    }
}
